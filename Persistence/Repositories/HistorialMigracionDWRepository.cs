using Application.IRepositories;
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class HistorialMigracionDWRepository : IHistorialMigracionDWRepository {
    private readonly DapperContext _context;
    public HistorialMigracionDWRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateHistorial(HistorialMigracionDW model) {
        var db = _context.CreateSmartSlotConnection();
        var sql = $@"
    INSERT INTO [dbo].[HistorialMigracionDW]
           ([fechamigracion]
           ,[iniciado]
           ,[terminado])
     VALUES
           (@fechamigracion
           ,@iniciado
           ,@terminado)
";
        var result = await db.ExecuteAsync(sql, model);
        return result > 0;
    }
    public async Task<HistorialMigracionDW?> GetByDate(DateTime fecha) {
        var db = _context.CreateSmartSlotConnection();
        var sql = $@"
SELECT [fechamigracion]
      ,[iniciado]
      ,[terminado]
  FROM [dbo].[HistorialMigracionDW] where fechamigracion = convert(date,@fecha)
";
        return  await db.QueryFirstOrDefaultAsync<HistorialMigracionDW>(sql, new { fecha = fecha});
    }

    public async Task<bool> UpdateInicio(DateTime fecha) {
        var db = _context.CreateSmartSlotConnection();
        var sql = $@"
        UPDATE [dbo].[HistorialMigracionDW]
            SET 
                [iniciado] = 1
            WHERE where where fechamigracion = convert(date,@fecha)
        ";
        var result = await db.ExecuteAsync(sql, new { fecha = fecha });
        return result > 0;
    }

    public async Task<bool> UpdateTermino(DateTime fecha) {
        var db = _context.CreateSmartSlotConnection();
        var sql = $@"
        UPDATE [dbo].[HistorialMigracionDW]
            SET 
                [terminado] = 1
            WHERE where fechamigracion = convert(date,@fecha)
        ";
        var result = await db.ExecuteAsync(sql, new { fecha = fecha });
        return result > 0;
    }
    public async Task<HistorialMigracionDW?> GetLastRecord() {
        var db = _context.CreateSmartSlotConnection();
        var sql = $@"
SELECT top 1 [fechamigracion]
      ,[iniciado]
      ,[terminado]
  FROM [dbo].[HistorialMigracionDW] 
order by fechamigracion desc
";
        return await db.QueryFirstOrDefaultAsync<HistorialMigracionDW?>(sql);
    }
}
