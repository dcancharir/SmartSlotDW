using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
internal class ClienteCategoriaProfile : Profile {
    public ClienteCategoriaProfile() {
        CreateMap<ClienteCategoria, ClienteCategoriaViewModel>().ReverseMap();
    }
}
