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

namespace Application.CommandsQueries.CanjeProductoCQ;
public class CrearCanjeProductoCommand : IRequest<bool> {
    public int codsala { get; set; }
    public List<CanjeProductoViewModel> registro { get; set; }
    public class CrearCanjeProductoCommandHandler : IRequestHandler<CrearCanjeProductoCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearCanjeProductoCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        public async Task<bool> Handle(CrearCanjeProductoCommand request, CancellationToken cancellationToken) {
            try {
                List<CanjeProducto> registros = _mapper.Map<List<CanjeProducto>>(request.registro);
                foreach(var canjeproducto in registros) {
                    canjeproducto.codsala = request.codsala;
                    var insertado = await _unitOfWork._canjeProductoRepository.CreateCanjeProducto(canjeproducto);
                    if(insertado > 0) {
                        foreach(var pedido in canjeproducto.pedido) {
                            pedido.canjeproductoid = insertado;
                            pedido.codsala = request.codsala;
                            await _unitOfWork._pedidoRepository.CreatePedido(pedido);
                        }
                    }
                }
                return true;
            } catch(Exception) {
                return false;
            }
        }
    }
}
