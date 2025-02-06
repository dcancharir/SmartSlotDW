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

namespace Application.CommandsQueries.ClienteCategoriaCQ;
public class CrearClienteCategoriaCommand : IRequest<bool> {
    public List<ClienteCategoriaViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class CrearClienteCategoriaCommandHandler : IRequestHandler<CrearClienteCategoriaCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClienteCategoriaCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer) {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(CrearClienteCategoriaCommand request, CancellationToken cancellationToken) {
            var response = false;
            if (request.registro == null) {
                return response;
            }
            try {
                List<ClienteCategoria> clientes = _mapper.Map<List<ClienteCategoria>>(request.registro);
                foreach (var item in clientes) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clienteCategoriaRepository.CreateClientCategoria(item);
                }
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
