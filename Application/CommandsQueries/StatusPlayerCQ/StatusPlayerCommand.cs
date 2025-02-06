using Application.CommandsQueries.ClienteCQ;
using Application.IRepositories;
using Application.ViewModels;
using AutoMapper;
using Domain;
using MediatR;
namespace Application.CommandsQueries.StatusPlayerCQ;
public class StatusPlayerCommand : IRequest<bool>
{
    public List<StatusPlayerViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class StatusPlayerCommandHandler : IRequestHandler<StatusPlayerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StatusPlayerCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(StatusPlayerCommand request, CancellationToken cancellationToken)
        {
            var response = false;
            if (request.registro == null)
            {
                return response;
            }
            try
            {
                List<StatusPlayer> registros = _mapper.Map<List<StatusPlayer>>(request.registro);
                foreach (var item in registros)
                {
                    item.codsala = request.codsala;
                    var dbResult = await _unitOfWork._statusPlayerRepository.CreateStatusPlayer(item);
                    if (dbResult > 0)
                    {
                        //insertar detalles
                        if(item.statusMaquinaCupon != null)
                        {
                            foreach(var detalle in item.statusMaquinaCupon)
                            {
                                detalle.codsala = request.codsala;
                                var result = await _unitOfWork._statusMaquinaCuponRepository.CreateStatusMaquinaCupon(detalle);

                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
