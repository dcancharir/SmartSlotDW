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
public class GetLastRecordHistorialMigracionDWCommand : IRequest<HistorialMigracionDWViewModel?> {
    public class GetLastRecordHistorialMigracionDWCommandHandler : IRequestHandler<GetLastRecordHistorialMigracionDWCommand, HistorialMigracionDWViewModel?> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetLastRecordHistorialMigracionDWCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<HistorialMigracionDWViewModel?> Handle(GetLastRecordHistorialMigracionDWCommand request,CancellationToken token) {
            HistorialMigracionDWViewModel? response;
            try {
                var result = await _unitOfWork._historialMigracionDWRepository.GetLastRecord();
                response = _mapper.Map<HistorialMigracionDWViewModel?>(result);
                return response;
            } catch(Exception) {
                response = null;
            }
            return response;
        }
    }
}