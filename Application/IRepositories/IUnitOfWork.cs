using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IUnitOfWork 
{
    IClienteRepository _clienteRepository {  get; }
    ISalaRepository _salaRepository { get; }
    IClienteCategoriaRepository _clienteCategoriaRepository { get; }
    IClienteCuponRepository _clienteCuponRepository { get; }
    IClientePromocionRepository _clientePromocionRepository { get; }
    IAfluenciaHoraRepository _afluenciaHoraRepository { get; }
    IStatusPlayerRepository _statusPlayerRepository { get; }
    IStatusMaquinaCuponRepository _statusMaquinaCuponRepository { get; }
    IPromocionRepository _promocionRepository{ get; }
    ISegmentacionClienteRepository _segmentacionClienteRepository { get; }
    ISorteoRepository _sorteoRepository { get; }
    IClientePuntoRepository _clientePuntoRepository { get; }
    IClientePuntoFechasRepository _clientePuntoFechasRepository {  get; }
    IHistorialCuponRepository _historialCuponRepository { get; }
    IClienteJugadaRepository _clienteJugadaRepository { get; }
    ISorteoConfiguracionRepository _sorteoConfiguracionRepository { get; }
    IMaquinasConfiguracionRepository _maquinasConfiguracionRepository { get; }
}
