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
public class ListarSorteosQuery : IRequest<IEnumerable<SorteoViewModel>>{
    public int codsala;
    public class ListarSorteosQueryHandler : IRequestHandler<ListarSorteosQuery, IEnumerable<SorteoViewModel>> {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ListarSorteosQueryHandler(IUnitOfWork unitOfwork, IMapper mapper) {
            _unitOfwork = unitOfwork ?? throw new ArgumentNullException(nameof(unitOfwork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<SorteoViewModel>> Handle(ListarSorteosQuery request,CancellationToken cancellationToken) {
            IEnumerable<Sorteo> result = await _unitOfwork._sorteoRepository.GetAllSorteoByCodSala(request.codsala);
            return _mapper.Map<IEnumerable<SorteoViewModel>>(result);
        }
    }
}
