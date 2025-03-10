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

namespace Application.CommandsQueries.HistorialCuponCQ;
public class RemoveHistorialCuponCommand : IRequest<bool> {
    public int codsala { get; set; }
    public DateTime fechaOperacion { get; set; }
    public class RemoveHistorialCuponCommandHandler : IRequestHandler<RemoveHistorialCuponCommand, bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RemoveHistorialCuponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> Handle(RemoveHistorialCuponCommand request, CancellationToken cancellationToken) {
            var response = false;
            if(request.codsala == 0) {
                return response;
            }
            try {
                var result = await _unitOfWork._historialCuponRepository.RemoveHistorialCupon(request.codsala,request.fechaOperacion);
                response = true;
            } catch(Exception) {
                response = false;
            }
            return response;
        }
    }
}
