using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IClienteRepository : IGenericCommandRepository<Cliente>,IGenericQueriesRepository<Cliente> {
    Task<bool> CreateClient(Cliente registro);
    Task<IEnumerable<Cliente>> GetAllClientByCodSala(int codsala);
}
