using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IClienteJugadaRepository {
    public Task<bool> RemoveClienteJugada(int codsala, DateTime fechaOperacion);
    public Task<bool> BulkCreateClienteJugada(List<ClienteJugada> lista);
}
