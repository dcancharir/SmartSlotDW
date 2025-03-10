using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class SorteoConfiguracion {
    public int codsala {  get; set; }
    public int sorteoconfiguracionid { get; set; }
    public int sorteoid { get; set; }
    public string nombre { get; set; }
    public double coinin {  get; set; }
    public double coinout { get; set; }
    public int cantidadpuntos {  get; set; }
    public double minimaapuesta {  get; set; }
    public double maximaapuesta { get; set; }
    public bool jackpot {  get; set; }
    public int cantidadcupones { get; set; }
    public List<MaquinasConfiguracion> maquinasconfiguracion { get; set; }
}
