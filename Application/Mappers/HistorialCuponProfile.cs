using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Mappers;
public class HistorialCuponProfile : Profile {
    public HistorialCuponProfile()
    {
        CreateMap<HistorialCupon, HistorialCuponViewModel>().ReverseMap();
    }
}
