using Application.CommandsQueries.StatusPlayerCQ;
using Application.IRepositories;
using Application.ViewModels;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsQueries.PromocionCQ;
public class PromocionCommand : IRequest<bool>
{
    public List<PromocionViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class PromocionCommandHandler : IRequestHandler<PromocionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PromocionCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(PromocionCommand request, CancellationToken cancellationToken)
        {
            var response = false;
            if (request.registro == null)
            {
                return response;
            }
            try
            {
                List<Promocion> registros = _mapper.Map<List<Promocion>>(request.registro);
                foreach (var item in registros)
                {
                    item.codsala = request.codsala;
                    await _unitOfWork._promocionRepository.CreatePromocion(item);
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
