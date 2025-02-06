using Application.CommandsQueries.ClienteCQ;
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

namespace Application.CommandsQueries.ClientePromocionCQ;
public class CrearClientePromocionCommand : IRequest<bool> {
    public List<ClientePromocionViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class CrearClientePromocionCommandHandler : IRequestHandler<CrearClientePromocionCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClientePromocionCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer) {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(CrearClientePromocionCommand request, CancellationToken cancellationToken) {
            var response = false;
            if (request.registro == null) {
                return response;
            }
            try {
                List<ClientePromocion> result = _mapper.Map<List<ClientePromocion>>(request.registro);
                foreach (var item in result) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clientePromocionRepository.CreateClientPromocion(item);
                }
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
