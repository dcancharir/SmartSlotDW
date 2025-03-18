using Application.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsQueries.HistorialMigracionDWCQ;
public class UpdateTerminoHistorialMigracionDWCommand :IRequest<bool>{
    public DateTime fecha { get; set; }
    public class UpdateTerminoHistorialMigracionDWCommandHandler : IRequestHandler<UpdateTerminoHistorialMigracionDWCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTerminoHistorialMigracionDWCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateTerminoHistorialMigracionDWCommand request, CancellationToken cancellationToken) {
            var response = false;
            try {
                var result = await _unitOfWork._historialMigracionDWRepository.UpdateTermino(request.fecha);
                response = result;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
