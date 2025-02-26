using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
public class ClienteCuponProfile : Profile {
    public ClienteCuponProfile() {
        //CreateMap<ClienteCupon, ClienteCuponViewModel>().ReverseMap();
        CreateMap<(ClienteCuponViewModel Cliente, DetalleCuponesViewModel detalle), ClienteCupon>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Cliente.id))
            .ForMember(dest => dest.clienteid, opt => opt.MapFrom(src => src.Cliente.clienteid))
            .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.Cliente.cliente))
            .ForMember(dest => dest.idSorteo, opt => opt.MapFrom(src => src.detalle.idSorteo))
            .ForMember(dest => dest.nombreSorteo, opt => opt.MapFrom(src => src.detalle.idSorteo))
            .ForMember(dest => dest.cuponesGenerados, opt => opt.MapFrom(src => src.detalle.cuponesGenerados))
            .ForMember(dest => dest.cuponesAsignados, opt => opt.MapFrom(src => src.detalle.cuponesAsignados))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.detalle.estado))
            .ForMember(dest=>dest.codsala,opt=>opt.MapFrom(src=>0));
    }
}
