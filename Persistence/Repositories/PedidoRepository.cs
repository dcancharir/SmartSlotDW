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
public class PedidoRepository : IPedidoRepository {
    private readonly DapperContext _context;
    public PedidoRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreatePedido(Pedido model) {
        var db = _context.CreateSmartSlotConnection();
        try {
            var result = await db.ExecuteAsync(PedidoQueries.Create, model);
            return result > 0;
        } catch(Exception) {
            return false;
        } finally {
            db.Close();
        }
    }
}
