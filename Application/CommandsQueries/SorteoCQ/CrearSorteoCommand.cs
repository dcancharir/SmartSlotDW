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
public class CrearSorteoCommand : IRequest<bool> {
    public List<SorteoViewModel> registro {  get; set; }
    public int codsala { get; set; }
    public class SorteoCommandHandler : IRequestHandler<CrearSorteoCommand,bool> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SorteoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> Handle(CrearSorteoCommand request,CancellationToken cancellationToken) {
            var response = false;
            if(request.registro == null) {
                return response;
            }
            try {
                var sorteosDb = await _unitOfWork._sorteoRepository.GetAllSorteoByCodSala(request.codsala);
                List<Sorteo> registros = _mapper.Map<List<Sorteo>>(request.registro);

                var sorteosInsertar = registros.Where(c2 => !sorteosDb.Any(c1 => c1.id == c2.id)).ToList();
                sorteosInsertar.ForEach(item => { 
                    item.codsala = request.codsala;
                });
                foreach(var item in sorteosInsertar) {
                    item.codsala = request.codsala;
                    var resultSorteo = await _unitOfWork._sorteoRepository.CreateSorteo(item);
                    if(resultSorteo == true) {
                        //detalles
                        foreach(var sorteoconfiguracion in item.listaSorteoConfiguracion) {
                            sorteoconfiguracion.codsala = request.codsala;
                            var resultSorteconfiguracion = await _unitOfWork._sorteoConfiguracionRepository.CreateSorteoConfiguracion(sorteoconfiguracion);
                            if(resultSorteconfiguracion == true && sorteoconfiguracion.maquinasconfiguracion.Count > 0) {
                                sorteoconfiguracion.maquinasconfiguracion.ForEach(x => {
                                    x.codsala = request.codsala;
                                });
                                var resultMaquinasConfiguracion = await _unitOfWork._maquinasConfiguracionRepository.BulkCreateMaquinasConfiguracion(sorteoconfiguracion.maquinasconfiguracion);
                            }
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
