using Application.IRepositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandsQueries.SalaCQ;
public class ListarSalasActivasQuery : IRequest<IEnumerable<SalaViewModel>>{
    public class ListarSalasActivasQueryHandler : IRequestHandler<ListarSalasActivasQuery, IEnumerable<SalaViewModel>> {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IMapper _mapper;
        public ListarSalasActivasQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfwork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SalaViewModel>> Handle(ListarSalasActivasQuery request,CancellationToken cancellationToken) {
            IEnumerable<SalaViewModel> response;
            try {
                var result = await _unitOfwork._salaRepository.ListarActivas();
                response = _mapper.Map<IEnumerable<SalaViewModel>>(result); 
            }
            catch (Exception) {
                response = new List<SalaViewModel>();
            }
            return response;
        }
    }
}
