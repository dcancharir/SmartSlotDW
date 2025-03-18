using Application.IRepositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.CommandsQueries.HistorialMigracionDWCQ;
public class GetByFechaHistorialMigracionDWQuery  : IRequest<HistorialMigracionDWViewModel?>{
    public DateTime fecha {  get; set; }
    public class GetByFechaHistorialMigracionDWQueryHandler : IRequestHandler<GetByFechaHistorialMigracionDWQuery, HistorialMigracionDWViewModel?> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByFechaHistorialMigracionDWQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HistorialMigracionDWViewModel?> Handle(GetByFechaHistorialMigracionDWQuery request, CancellationToken cancellationToken) {
            HistorialMigracionDWViewModel? response;
            try {
                var result = await _unitOfWork._historialMigracionDWRepository.GetByDate(request.fecha);
                response = _mapper.Map<HistorialMigracionDWViewModel>(result);
            } catch(Exception ex) {
                response = null;
            }
            return response;
        }
    }
}
