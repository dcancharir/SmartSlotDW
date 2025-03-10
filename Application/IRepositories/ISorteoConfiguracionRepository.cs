using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface ISorteoConfiguracionRepository {
    public Task<bool> CreateSorteoConfiguracion(SorteoConfiguracion registro);
}
