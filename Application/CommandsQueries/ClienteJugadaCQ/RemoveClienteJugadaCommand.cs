using Application.IRepositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsQueries.ClienteJugadaCQ;
public class RemoveClienteJugadaCommand : IRequest<bool> {
    public int codsala {  get; set; }
    public DateTime fechaOperacion { get; set; }
    public class RemoveClienteJugadaCommandHandler : IRequestHandler<RemoveClienteJugadaCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RemoveClienteJugadaCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RemoveClienteJugadaCommand request, CancellationToken cancellationToken) {
            var response = false;
            if(request.codsala == 0) {
                return response;
            }
            try {
                var result = await _unitOfWork._clienteJugadaRepository.RemoveClienteJugada(request.codsala, request.fechaOperacion.Date);
                response = true;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
