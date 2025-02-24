using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;
using Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class StatusMaquinaCuponRepository : IStatusMaquinaCuponRepository
{
    private readonly DapperContext _context;
    public StatusMaquinaCuponRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateStatusMaquinaCupon(StatusMaquinaCupon registro)
    {
        var db = _context.CreateSmartSlotConnection();
        bool result = false;
        try
        {
            var res = await db.ExecuteAsync(StatusMaquinaCuponQueries.Create, registro);
            result = res > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        }
        finally
        {
            db.Close();
        }
        return result;
    }
    public async Task<bool> BulkCreateStatusMaquinaCupon(List<StatusMaquinaCupon> lista) {
        bool result = false;
        try {
            using(var connection = new SqlConnection(_context.GetSmartSlotConnection())) {
                await connection.OpenAsync();

                // Convierte la lista a un DataTable
                var dataTable = lista.ToDataTable();

                // Llamada asincrónica para realizar el Bulk Insert
                await BulkInsertAsync(connection, dataTable);
                result = true;
            }
        } catch(Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {

        }
        return result;
    }
    private static async Task BulkInsertAsync(SqlConnection connection, DataTable dataTable) {
        using(var bulkCopy = new SqlBulkCopy(connection)) {
            bulkCopy.DestinationTableName = "StatusMaquinaCupon";  // Nombre de la tabla destino en la base de datos

            // Asignar un Task para manejar el proceso asincrónicamente
            await Task.Run(() => {
                bulkCopy.WriteToServer(dataTable);  // Inserta los datos de forma masiva
            });
        }
    }
}
