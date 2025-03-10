using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;
namespace Persistence.Repositories;
public class SorteoConfiguracionRepository : ISorteoConfiguracionRepository{
    private readonly DapperContext _context;
    public SorteoConfiguracionRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateSorteoConfiguracion(SorteoConfiguracion registro) {
        var db = _context.CreateSmartSlotConnection();
        bool result = false;
        try {
            var res = await db.ExecuteAsync(SorteoConfiguracionQueries.Create, registro);
            result = res > 0;
        } catch(Exception ex) {
            Console.WriteLine($"Error fetching records from db: ${ex.Message}");
            throw new Exception("Unable to fetch data. Please contact the administrator.");
        } finally {
            db.Close();
        }
        return result;
    }
}
