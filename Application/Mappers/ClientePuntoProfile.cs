using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Mappers;
public class ClientePuntoProfile : Profile{
    public ClientePuntoProfile()
    {
        CreateMap<ClientePunto, ClientePuntoViewModel>().ReverseMap();
    }
}
