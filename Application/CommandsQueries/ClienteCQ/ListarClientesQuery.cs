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

namespace Application.CommandsQueries.ClienteCQ;
public class ListarClientesQuery : IRequest<IEnumerable<ClienteViewModel>> {
    public int codsala;
    public class ListarClientesQueryHandler : IRequestHandler<ListarClientesQuery, IEnumerable<ClienteViewModel>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ListarClientesQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteViewModel>> Handle(ListarClientesQuery request, CancellationToken cancellationToken) {

            IEnumerable<Cliente> result = await _unitOfWork._clienteRepository.GetAllClientByCodSala(request.codsala);
            return _mapper.Map<IEnumerable<ClienteViewModel>>(result);
        }
    }
}
