﻿using Application.ViewModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers;
internal class SalaProfile : Profile {
    public SalaProfile() {
        CreateMap<Sala, SalaViewModel>().ReverseMap();
    }
}
