using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Sorteo {
    public int codsala { get; set; }
    public int id {  get; set; }
    //public SorteoBono sorteobono { get; set; }
    //public SorteoConfiguracion sorteoconfiguracion {  get; set; }
    public string descripcion { get; set; }
    public DateTime fechaInicioSorteo { get; set; }
    public DateTime fechaFinSorteo { get; set; }
    public int sorteovirtual { get; set; }
    public string estado { get; set; }
    public string tipo { get; set; }
    public List<SorteoConfiguracion> listaSorteoConfiguracion { get; set; } = new List<SorteoConfiguracion>();
    public List<SorteoConfiguracionMaquina> listaSorteoConfiguracionMaquina { get; set; } = new List<SorteoConfiguracionMaquina>();
}
