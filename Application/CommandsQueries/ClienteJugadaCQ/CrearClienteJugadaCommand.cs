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

namespace Application.CommandsQueries.ClienteJugadaCQ;
public class CrearClienteJugadaCommand : IRequest<bool> {
    public List<ClienteJugadaViewModel> registro {  get; set; }
    public int codsala { get; set; }
    public DateTime fechaOperacion { get; set; }
    public class CrearClienteJugadaCommandHandler : IRequestHandler<CrearClienteJugadaCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearClienteJugadaCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CrearClienteJugadaCommand request,CancellationToken cancellationToken) {
            var response = false;
            if (request.registro == null) {
                return response;
            }
            try {
                List<ClienteJugada> registros = request.registro.ToClienteJugadaList(_mapper);
                registros.ForEach(registro => { 
                    registro.codsala = request.codsala;
                    registro.fechadw = request.fechaOperacion.Date;
                });
                var resul = await _unitOfWork._clienteJugadaRepository.BulkCreateClienteJugada(registros);
                response = true;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
