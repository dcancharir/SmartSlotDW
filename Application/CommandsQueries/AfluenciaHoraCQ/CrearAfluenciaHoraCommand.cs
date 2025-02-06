using Application.CommandsQueries.ClienteCQ;
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

namespace Application.CommandsQueries.AfluenciaHoraCQ;
public class CrearAfluenciaHoraCommand : IRequest<bool>
{
    public List<AfluenciaHoraViewModel> registro { get; set; }
    public int codsala { get; set; }
    public class CrearAfluenciaHoraCommandHandler : IRequestHandler<CrearAfluenciaHoraCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CrearAfluenciaHoraCommandHandler(IUnitOfWork unitOfWork, IMapper mapeer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapeer;
        }
        public async Task<bool> Handle(CrearAfluenciaHoraCommand request, CancellationToken cancellationToken)
        {
            var response = false;
            if (request.registro == null)
            {
                return response;
            }
            try
            {
                List<AfluenciaHora> registros = _mapper.Map<List<AfluenciaHora>>(request.registro);
                foreach (var item in registros)
                {
                    item.codsala = request.codsala;
                    await _unitOfWork._afluenciaHoraRepository.CreateAfluenciaHora(item);
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
