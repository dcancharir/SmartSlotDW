using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class MaquinasConfiguracionViewModel {
    public int sorteoconfiguracionid { get; set; }
    public string? maquina {  get; set; }
    public string? marca { get; set; }
    public string? tipomaquina { get; set; }
}
