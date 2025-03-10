using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IHistorialCuponRepository {
    public Task<bool> RemoveHistorialCupon(int codsala, DateTime fechaOperacion);
    public Task<bool> BulkCreateHistorialCupon(List<HistorialCupon> lista);
}
