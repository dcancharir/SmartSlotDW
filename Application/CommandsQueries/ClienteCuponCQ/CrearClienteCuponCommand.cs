using Application.CommandsQueries.ClienteCategoriaCQ;
using Application.Extensions;
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

namespace Application.CommandsQueries.ClienteCuponCQ;
public class CrearClienteCuponCommand : IRequest<bool> {
    public List<ClienteCuponViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class CrearClienteCuponCommandHandler : IRequestHandler<CrearClienteCuponCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClienteCuponCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer) {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(CrearClienteCuponCommand request, CancellationToken cancellationToken) {
            var response = false;
            if (request.registro == null) {
                return response;
            }
            try {
                List<ClienteCupon> clientes = request.registro.ToClienteCuponList(_mapper);
                foreach (var item in clientes) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clienteCuponRepository.CreateClientCupon(item);
                }
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
