using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;
using Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Persistence.Repositories;
public class HistorialCuponRepository : IHistorialCuponRepository {
    private readonly DapperContext _context;
    public HistorialCuponRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> RemoveHistorialCupon(int codsala,DateTime fechaOperacion) {
        var db = _context.CreateSmartSlotConnection();
        var result = await db.ExecuteAsync(HistorialCuponQueries.Remove, new {codsala=codsala,fechadw = fechaOperacion.Date });
        return result > 0;
    }
    public async Task<bool> BulkCreateHistorialCupon(List<HistorialCupon> lista) {
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
            bulkCopy.DestinationTableName = "HistorialCupon";  // Nombre de la tabla destino en la base de datos
            // Add explicit column mappings to ensure correct data type conversion
            bulkCopy.ColumnMappings.Add("fechadw", "fechadw");
            bulkCopy.ColumnMappings.Add("codsala", "codsala");
            bulkCopy.ColumnMappings.Add("clienteid", "clienteid");
            bulkCopy.ColumnMappings.Add("cliente", "cliente");
            bulkCopy.ColumnMappings.Add("sorteoid", "sorteoid");
            bulkCopy.ColumnMappings.Add("nombreSorteo", "nombreSorteo");
            bulkCopy.ColumnMappings.Add("fecha", "fecha");
            bulkCopy.ColumnMappings.Add("tipoCupon", "tipoCupon");
            bulkCopy.ColumnMappings.Add("cupones", "cupones");
            bulkCopy.ColumnMappings.Add("estadoSorteo", "estadoSorteo");
            // Asignar un Task para manejar el proceso asincrónicamente
            await Task.Run(() => {
                bulkCopy.WriteToServer(dataTable);  // Inserta los datos de forma masiva
            });
        }
    }
}
