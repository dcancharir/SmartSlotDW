using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IHistorialMigracionDWRepository {
    public Task<HistorialMigracionDW?> GetByDate(DateTime fecha);
    public Task<bool> UpdateInicio(DateTime fecha);
    public Task<bool> UpdateTermino(DateTime fecha);
    public Task<bool> CreateHistorial(HistorialMigracionDW model);
    public Task<HistorialMigracionDW?> GetLastRecord();
    public Task<IEnumerable<HistorialMigracionDW>> GetDiasFaltantesMigracion();
}
