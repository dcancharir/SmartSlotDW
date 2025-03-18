using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.CommandsQueries.HistorialMigracionDWCQ;
public class UpdateInicioHistorialMigracionDWCommand : IRequest<bool>{
    public DateTime fecha { get; set; }
    public class UpdateInicioHistorialMigracionDWCommandHandler : IRequestHandler<UpdateInicioHistorialMigracionDWCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateInicioHistorialMigracionDWCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateInicioHistorialMigracionDWCommand request,CancellationToken token) {
            var response = false;
            try {
                var result = await _unitOfWork._historialMigracionDWRepository.UpdateInicio(request.fecha);
                response = result;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
