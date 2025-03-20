using Application.IRepositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsQueries.HistorialMigracionDWCQ;
public class GetDiasFaltantesMigracionDWQuery : IRequest<HistorialMigracionDWViewModel>{
    //public class GetDiasFaltantesMigracionDWQueryHandler : IRequestHandler<GetDiasFaltantesMigracionDWQuery,IEnumerable<HistorialMigracionDWViewModel>?> {
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;
    //    public GetDiasFaltantesMigracionDWQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }
    //    public async Task<IEnumerable<HistorialMigracionDWViewModel>?> Handle(GetDiasFaltantesMigracionDWQuery request,CancellationToken cancellationToken) {
    //        IEnumerable<HistorialMigracionDWViewModel>? response;
    //        try {
    //            var result = await _unitOfWork._historialMigracionDWRepository.GetDiasFaltantesMigracion();
    //            response = _mapper.Map<IEnumerable<HistorialMigracionDWViewModel>>(result);
    //            return response;
    //        } catch(Exception) {
    //            response = null;
    //        }
    //        return response;
    //    }
    //}
}
