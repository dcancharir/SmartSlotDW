using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
internal class SalaRepository : ISalaRepository {
    private readonly DapperContext _context;
    public SalaRepository(DapperContext context) {
        _context = context;
    }
    public async Task<IEnumerable<Sala>> ListarActivas() {
        var db = _context.CreateSmartSlotConnection();
        IEnumerable<Sala> result;
        try {
            result = await db.QueryAsync<Sala>(sql: SalaQueries.SelectActives);
            //result = await db.QueryAsync<Empleado>(EmpleadoQueries.ListarWhere(where));
        }
        catch (Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {
            db.Close();
        }

        return result.ToList();
    }
}
