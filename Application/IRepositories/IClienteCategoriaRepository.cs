using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IClienteCategoriaRepository {
    Task<bool> CreateClientCategoria(ClienteCategoria registro);
}
