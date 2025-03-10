using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class SorteoConfiguracionViewModel {
    public int sorteoconfiguracionid { get; set; }
    public int sorteoid { get; set; }
    public string? nombre { get; set; }
    public double coinin { get; set; }
    public double coinout { get; set; }
    public int cantidadpuntos { get; set; }
    public double minimaapuesta { get; set; }
    public double maximaapuesta { get;set; }
    public bool jackpot {  get; set; }
    public int cantidadcupones { get; set; }
    public List<MaquinasConfiguracionViewModel> maquinasconfiguracion { get; set; } = new List<MaquinasConfiguracionViewModel>();
}
