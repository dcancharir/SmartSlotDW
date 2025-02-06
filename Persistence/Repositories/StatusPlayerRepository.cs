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
public class StatusPlayerRepository : IStatusPlayerRepository
{
    private readonly DapperContext _context;
    public StatusPlayerRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<int> CreateStatusPlayer(StatusPlayer registro)
    {
        int result;
        var db = _context.CreateSmartSlotConnection();
        try
        {
            var res = await db.QueryAsync<int>(StatusPlayerQueries.Create, registro);
            result = res.Single();
        }
        catch (Exception ex)
        {
            result = 0;
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        }
        finally
        {
            db.Close();
        }
        return result;
    }
}
