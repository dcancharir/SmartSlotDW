using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Mappers;
internal class ClientePuntoFechasProfile : Profile{
    public ClientePuntoFechasProfile()
    {
        CreateMap<ClientePuntoFechas, ClientePuntoFechasViewModel>().ReverseMap();
    }
}
