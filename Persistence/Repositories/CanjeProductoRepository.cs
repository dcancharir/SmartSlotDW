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
public class CanjeProductoRepository : ICanjeProductoRepository {
    private readonly DapperContext _context;
    public CanjeProductoRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<int> CreateCanjeProducto(CanjeProducto item) {
        var db = _context.CreateSmartSlotConnection();
        try {
            var result = await db.QueryAsync<int>(CanjeProductoQueries.Create, item);
            return result.Single();
        } catch(Exception) {
            return 0;
        } finally {
            db.Close();
        }
    }
}
