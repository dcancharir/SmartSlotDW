using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
public class ClienteJugadaProfile : Profile{
    public ClienteJugadaProfile()
    {
        CreateMap<(ClienteJugadaViewModel cliente, ClienteJugadaMaquinaBGViewModel maquinabg, ClienteJugadaCuponViewModel jugadacupon), ClienteJugada>()
         .ForMember(dest => dest.clientejugadamaquinabgmodelo, opt => opt.MapFrom(src => src.maquinabg.modelo))
         .ForMember(dest => dest.clientejugadamaquinabgjuego, opt => opt.MapFrom(src => src.maquinabg.juego))
         .ForMember(dest => dest.clientejugadamaquinabgserie, opt => opt.MapFrom(src => src.maquinabg.serie))
         .ForMember(dest => dest.clientejugadamaquinabgtotalpuntos, opt => opt.MapFrom(src => src.maquinabg.totalpuntos))
         .ForMember(dest => dest.clientejugadamaquinabgresiduo, opt => opt.MapFrom(src => src.maquinabg.residuo))
         .ForMember(dest => dest.clientejugadamaquinabgjugadas_calculadas, opt => opt.MapFrom(src => src.maquinabg.jugadas_calculadas))
         .ForMember(dest => dest.clientejugadacuponsorteoid, opt => opt.MapFrom(src => src.jugadacupon.sorteoid))
         .ForMember(dest => dest.clientejugadacuponcupones, opt => opt.MapFrom(src => src.jugadacupon.cupones))
         .ForMember(dest => dest.clientejugadamaquinabgresiduo, opt => opt.MapFrom(src => src.jugadacupon.residuo));
    }
}
