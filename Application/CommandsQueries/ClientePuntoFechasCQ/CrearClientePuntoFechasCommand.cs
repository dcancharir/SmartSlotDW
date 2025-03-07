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

namespace Application.CommandsQueries.ClientePuntoFechasCQ;
public class CrearClientePuntoFechasCommand : IRequest<bool>{
    public List<ClientePuntoFechasViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class ClientePuntoFechasCommandHandler : IRequestHandler<CrearClientePuntoFechasCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClientePuntoFechasCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer) {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(CrearClientePuntoFechasCommand request, CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                List<ClientePuntoFechas> items = _mapper.Map<List<ClientePuntoFechas>>(request.registro);
                foreach(var item in items) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clientePuntoFechasRepository.CreateClientePuntoFechas(item);
                }
                return true;
            } catch(Exception) {
                return false;
            }
        }
    }
}
