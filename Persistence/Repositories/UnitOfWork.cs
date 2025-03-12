using Application.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class UnitOfWork : IUnitOfWork {
    public UnitOfWork(
        IClienteRepository clienteRepository,
        ISalaRepository salaRepository,
        IClienteCategoriaRepository clienteCategoriaRepository,
        IClienteCuponRepository clienteCuponRepository,
        IClientePromocionRepository clientePromocionRepository,
        IAfluenciaHoraRepository afluenciaHoraRepository,
        IStatusPlayerRepository statusPlayerRepository,
        IStatusMaquinaCuponRepository statusMaquinaCuponRepository,
        IPromocionRepository promocionRepository,
        ISegmentacionClienteRepository segmentacionClienteRepository,
        ISorteoRepository sorteoRepository,
        IClientePuntoRepository clientePuntoRepository,
        IClientePuntoFechasRepository clientePuntoFechasRepository,
        IHistorialCuponRepository historialCuponRepository,
        IClienteJugadaRepository clienteJugadaRepository,
        ISorteoConfiguracionRepository sorteoConfiguracionRepository,
        IMaquinasConfiguracionRepository maquinasConfiguracionRepository,
        ICanjeProductoRepository canjeProductoRepository,
        IPedidoRepository pedidoRepository)
    {
        _clienteRepository = clienteRepository;
        _salaRepository = salaRepository;
        _clienteCategoriaRepository = clienteCategoriaRepository;
        _clienteCuponRepository = clienteCuponRepository;
        _clientePromocionRepository = clientePromocionRepository;
        _afluenciaHoraRepository = afluenciaHoraRepository;
        _statusPlayerRepository = statusPlayerRepository;
        _statusMaquinaCuponRepository = statusMaquinaCuponRepository;
        _promocionRepository = promocionRepository;
        _segmentacionClienteRepository = segmentacionClienteRepository;
        _sorteoRepository = sorteoRepository;
        _clientePuntoRepository = clientePuntoRepository;
        _clientePuntoFechasRepository = clientePuntoFechasRepository;
        _historialCuponRepository = historialCuponRepository;
        _clienteJugadaRepository = clienteJugadaRepository;
        _sorteoConfiguracionRepository = sorteoConfiguracionRepository;
        _maquinasConfiguracionRepository = maquinasConfiguracionRepository;
        _canjeProductoRepository = canjeProductoRepository;
        _pedidoRepository = pedidoRepository;
    }
    public IClienteRepository _clienteRepository { get; }
    public ISalaRepository _salaRepository { get; }
    public IClienteCategoriaRepository _clienteCategoriaRepository { get; }
    public IClienteCuponRepository _clienteCuponRepository { get; }
    public IClientePromocionRepository _clientePromocionRepository { get; }
    public IAfluenciaHoraRepository _afluenciaHoraRepository { get; }
    public IStatusPlayerRepository _statusPlayerRepository{ get; }
    public IStatusMaquinaCuponRepository _statusMaquinaCuponRepository { get; }
    public IPromocionRepository _promocionRepository { get; }
    public ISegmentacionClienteRepository _segmentacionClienteRepository { get; }
    public ISorteoRepository _sorteoRepository { get; }
    public IClientePuntoRepository _clientePuntoRepository { get; }
    public IClientePuntoFechasRepository _clientePuntoFechasRepository { get; }
    public IHistorialCuponRepository _historialCuponRepository { get; }

    public IClienteJugadaRepository _clienteJugadaRepository { get; }

    public ISorteoConfiguracionRepository _sorteoConfiguracionRepository { get; }

    public IMaquinasConfiguracionRepository _maquinasConfiguracionRepository { get; }
    public ICanjeProductoRepository _canjeProductoRepository { get; }
    public IPedidoRepository _pedidoRepository { get; }
}
