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

namespace Application.CommandsQueries.ClienteCQ;
public class CrearClienteCommand : IRequest<bool> {
    public List<ClienteViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClienteCommandHandler(IUnitOfWork unitOfWork,IMapper mapeer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;   
        }
        public async Task<bool> Handle(CrearClienteCommand request, CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                List<Cliente> clientes = _mapper.Map<List<Cliente>>(request.registro);
                foreach (var item in clientes) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clienteRepository.CreateClient(item);
                }
                return true;
            } catch(Exception) {
                return false;
            }
        }
    }
}

