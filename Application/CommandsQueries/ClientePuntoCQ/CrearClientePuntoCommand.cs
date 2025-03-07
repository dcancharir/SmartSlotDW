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

namespace Application.CommandsQueries.ClientePuntoCQ;
public class CrearClientePuntoCommand : IRequest<bool> {
    public List<ClientePuntoViewModel> registro {  get; set; }
    public int codsala { get; set; }
    public class CrearClientePuntoCommandHandler : IRequestHandler<CrearClientePuntoCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClientePuntoCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CrearClientePuntoCommand request,CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                List<ClientePunto> items = _mapper.Map<List<ClientePunto>>(request.registro);
                foreach(var item in items) {
                    item.codsala = request.codsala;
                    await _unitOfWork._clientePuntoRepository.CreateClientePunto(item);
                }
                return true;
            } catch(Exception ex) {

                throw;
            }
        }
    }
}
