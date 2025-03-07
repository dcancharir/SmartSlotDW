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
                var fechaActual = DateTime.Now;
                var clientesDb = await _unitOfWork._clienteRepository.GetAllClientByCodSala(request.codsala);
                List<Cliente> clientes = _mapper.Map<List<Cliente>>(request.registro);

                var clientesInsertar = clientes.Where(c2 => !clientesDb.Any(c1 => c1.id == c2.id)).ToList();
                clientesInsertar.ForEach(x => { 
                    x.codsala = request.codsala;
                    x.fecharegistrodw = fechaActual;
                });
                response = await _unitOfWork._clienteRepository.BulkCreateClient(clientesInsertar);
                //foreach (var item in clientesInsertar) {
                //    item.codsala = request.codsala;
                //    await _unitOfWork._clienteRepository.CreateClient(item);
                //}
                return response;
            } catch(Exception) {
                return false;
            }
        }
    }
}

