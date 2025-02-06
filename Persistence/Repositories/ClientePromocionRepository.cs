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
public class ClientePromocionRepository : IClientePromocionRepository {
    private readonly DapperContext _context;
    public ClientePromocionRepository(DapperContext context) {
        _context = context;
    }
    public async Task<bool> CreateClientPromocion(ClientePromocion registro) {
        var db = _context.CreateSmartSlotConnection();
        bool result = false;
        try {
            var res = await db.ExecuteAsync(ClientePromocionQueries.Create, registro);
            result = res > 0;
        }
        catch (Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {
            db.Close();
        }
        return result;
    }
}
