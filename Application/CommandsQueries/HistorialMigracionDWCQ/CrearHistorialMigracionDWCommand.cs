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
    public List<HistorialMigracionDWViewModel> registro {  get; set; }
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
                List<HistorialMigracionDW> models = _mapper.Map<List<HistorialMigracionDW>>(request.registro);
                foreach(var model in models) {
                    try {
                        var result = await _unitOfWork._historialMigracionDWRepository.CreateHistorial(model);

                    } catch(Exception) {
                    }
                }
                return true;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
