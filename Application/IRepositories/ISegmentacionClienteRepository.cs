﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface ISegmentacionClienteRepository
{
    Task<bool> CreateSegmentacionCliente(SegmentacionCliente registro);
}
