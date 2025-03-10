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

namespace Application.CommandsQueries.HistorialCuponCQ;
public class CrearHistorialCuponCommand : IRequest<bool> {
    public List<HistorialCuponViewModel> registro {  get; set; }
    public int codsala { get; set; }
    public DateTime fechaOperacion { get; set; }
    public class CrearHistorialCuponCommandHandler : IRequestHandler<CrearHistorialCuponCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearHistorialCuponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> Handle(CrearHistorialCuponCommand request,CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                List<HistorialCupon> registros = _mapper.Map<List<HistorialCupon>>(request.registro);
                registros.ForEach(registro => { 
                    registro.codsala = request.codsala;
                    registro.fechadw = request.fechaOperacion.Date;
                });
                var result = await _unitOfWork._historialCuponRepository.BulkCreateHistorialCupon(registros);
                response = true;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }

}
