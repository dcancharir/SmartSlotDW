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
        ISorteoRepository sorteoRepository)
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
}
