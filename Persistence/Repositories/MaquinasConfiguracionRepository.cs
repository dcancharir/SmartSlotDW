using Domain;
using Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IRepositories;

namespace Persistence.Repositories;
public class MaquinasConfiguracionRepository : IMaquinasConfiguracionRepository {
    private readonly DapperContext _context;
    public MaquinasConfiguracionRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> BulkCreateMaquinasConfiguracion(List<MaquinasConfiguracion> lista) {
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
            bulkCopy.DestinationTableName = "MaquinasConfiguracion";  // Nombre de la tabla destino en la base de datos
            // Add explicit column mappings to ensure correct data type conversion
            bulkCopy.ColumnMappings.Add("codsala", "codsala");
            bulkCopy.ColumnMappings.Add("sorteoconfiguracionid", "sorteoconfiguracionid");
            bulkCopy.ColumnMappings.Add("maquina", "maquina");
            bulkCopy.ColumnMappings.Add("marca", "marca");
            bulkCopy.ColumnMappings.Add("tipomaquina", "tipomaquina");
            // Asignar un Task para manejar el proceso asincrónicamente
            await Task.Run(() => {
                bulkCopy.WriteToServer(dataTable);  // Inserta los datos de forma masiva
            });
        }
    }
}
