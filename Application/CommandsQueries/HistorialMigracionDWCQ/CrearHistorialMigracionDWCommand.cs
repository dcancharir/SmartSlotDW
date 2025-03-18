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

namespace Application.CommandsQueries.HistorialMigracionDWCQ;
public class CrearHistorialMigracionDWCommand : IRequest<bool> {
    public HistorialMigracionDWViewModel registro {  get; set; }
    public class CrearHistorialMigracionDWCommandHandler : IRequestHandler<CrearHistorialMigracionDWCommand,bool>{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearHistorialMigracionDWCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CrearHistorialMigracionDWCommand request,CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                HistorialMigracionDW model = _mapper.Map<HistorialMigracionDW>(request.registro);
                var result = await _unitOfWork._historialMigracionDWRepository.CreateHistorial(model);
                return result;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
