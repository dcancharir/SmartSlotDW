using Dapper;
using Domain;
using Persistence.dbQueries;
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
public class ClienteJugadaRepository : IClienteJugadaRepository {
    private readonly DapperContext _context;
    public ClienteJugadaRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> RemoveClienteJugada(int codsala,DateTime fechaOperacion) {
        var db = _context.CreateSmartSlotConnection();
        var result = await db.ExecuteAsync(ClienteJugadaQueries.Remove, new { codsala = codsala,fechadw = fechaOperacion.Date });
        return result > 0;
    }
    public async Task<bool> BulkCreateClienteJugada(List<ClienteJugada> lista) {
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
            bulkCopy.DestinationTableName = "ClienteJugada";  // Nombre de la tabla destino en la base de datos
            // Add explicit column mappings to ensure correct data type conversion
            bulkCopy.ColumnMappings.Add("codsala", "codsala");
            bulkCopy.ColumnMappings.Add("fechadw", "fechadw");
            bulkCopy.ColumnMappings.Add("clienteid", "clienteid");
            bulkCopy.ColumnMappings.Add("maquina", "maquina");
            bulkCopy.ColumnMappings.Add("fecha", "fecha");
            bulkCopy.ColumnMappings.Add("clientejugadaMaquinaBgId", "clientejugadaMaquinaBgId");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgmodelo", "clientejugadamaquinabgmodelo");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgjuego", "clientejugadamaquinabgjuego");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgserie", "clientejugadamaquinabgserie");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgtotalpuntos", "clientejugadamaquinabgtotalpuntos");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgresiduo", "clientejugadamaquinabgresiduo");
            bulkCopy.ColumnMappings.Add("clientejugadamaquinabgjugadas_calculadas", "clientejugadamaquinabgjugadas_calculadas");
            bulkCopy.ColumnMappings.Add("clientejugadacuponsorteoid", "clientejugadacuponsorteoid");
            bulkCopy.ColumnMappings.Add("clientejugadacuponcupones", "clientejugadacuponcupones");
            bulkCopy.ColumnMappings.Add("clientejugadacuponresiduo", "clientejugadacuponresiduo");
            // Asignar un Task para manejar el proceso asincrónicamente
            await Task.Run(() => {
                bulkCopy.WriteToServer(dataTable);  // Inserta los datos de forma masiva
            });
        }
    }
}
