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

namespace Application.CommandsQueries.SorteoCQ;
public class SorteoCommand : IRequest<bool> {
    public List<SorteoViewModel> registro {  get; set; }
    public int codsala { get; set; }
    public class SorteoCommandHandler : IRequestHandler<SorteoCommand,bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SorteoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> Handle(SorteoCommand request,CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                List<Sorteo> registros = _mapper.Map<List<Sorteo>>(request.registro);
                foreach(var item in registros) {
                    item.codsala = request.codsala;
                    await _unitOfWork._sorteoRepository.CreateSorteo(item);
                }
                return true;
            } catch(Exception) {
                return false;
            }
        }
    }
}
