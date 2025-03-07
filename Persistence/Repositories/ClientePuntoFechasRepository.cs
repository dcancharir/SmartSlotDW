using Application.IRepositories;
using Dapper;
using Domain;
using Persistence.dbQueries;


namespace Persistence.Repositories;
public class ClientePuntoFechasRepository: IClientePuntoFechasRepository {
    private readonly DapperContext _context;
    public ClientePuntoFechasRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateClientePuntoFechas(ClientePuntoFechas registro) {
        var db = _context.CreateSmartSlotConnection();
        bool result = false;
        try {
            var res = await db.ExecuteAsync(ClientePuntoFechasQueries.Create, registro);
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
