using Application.CommandsQueries.PromocionCQ;
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

namespace Application.CommandsQueries.SegmentacionClienteCQ;
public class SegmentacionClienteCommand:IRequest<bool>
{
    public List<SegmentacionClienteViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class SegmentacionClienteCommandHandler : IRequestHandler<SegmentacionClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SegmentacionClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(SegmentacionClienteCommand request, CancellationToken cancellationToken)
        {
            var response = false;
            if (request.registro == null)
            {
                return response;
            }
            try
            {
                List<SegmentacionCliente> registros = _mapper.Map<List<SegmentacionCliente>>(request.registro);
                foreach (var item in registros)
                {
                    item.codsala = request.codsala;
                    await _unitOfWork._segmentacionClienteRepository.CreateSegmentacionCliente(item);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
