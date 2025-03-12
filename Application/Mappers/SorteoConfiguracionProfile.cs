using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
public class SorteoConfiguracionProfile : Profile{
    public SorteoConfiguracionProfile()
    {
        CreateMap<SorteoConfiguracion,SorteoConfiguracionViewModel>().ReverseMap();
    }
}
