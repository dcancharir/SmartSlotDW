using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
internal class ClientePromocionProfile : Profile {
    public ClientePromocionProfile() {

        //CreateMap<ClientePromocion, ClientePromocionViewModel>().ReverseMap();
        // Mapeo que toma un ClientePromocionViewModel y una promoción individual
        // y lo convierte en un ClientePromocion
        CreateMap<(ClientePromocionViewModel Cliente, PromocionesGanadasViewModel Promocion), ClientePromocion>()
            .ForMember(dest => dest.clienteid, opt => opt.MapFrom(src => src.Cliente.id))
            .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.Cliente.cliente))
            .ForMember(dest => dest.tipodocumento, opt => opt.MapFrom(src => src.Cliente.tipodocumento))
            .ForMember(dest => dest.dni, opt => opt.MapFrom(src => src.Cliente.dni))
            .ForMember(dest => dest.categoria, opt => opt.MapFrom(src => src.Cliente.categoria))
            .ForMember(dest => dest.promocionid, opt => opt.MapFrom(src => src.Promocion.idPromocion))
            .ForMember(dest => dest.promocion, opt => opt.MapFrom(src => src.Promocion.promocion))
            .ForMember(dest => dest.tipopromocion, opt => opt.MapFrom(src => src.Promocion.tipopromocion))
            .ForMember(dest => dest.fechagenerado, opt => opt.MapFrom(src => src.Promocion.fechagenerado))
            .ForMember(dest => dest.fechacanje, opt => opt.MapFrom(src => src.Promocion.fechacanje))
            .ForMember(dest => dest.premioGanado, opt => opt.MapFrom(src => src.Promocion.premioGanado))
            .ForMember(dest => dest.premio, opt => opt.MapFrom(src => src.Promocion.premio))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.Promocion.estado))
            .ForMember(dest => dest.codsala, opt => opt.MapFrom(src => 0)); // Valor predeterminado
    }
}
