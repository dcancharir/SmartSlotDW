using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClientePromocion {
    public int codsala { get; set; }
    public int clienteid { get; set; }
    public int promocionid { get; set; }
    public string cliente { get; set; }
    public string tipodocumento{ get; set; }
    public string dni { get; set; }
    public string categoria { get; set; }
    public string promocion { get; set; }
    public string tipopromocion { get; set; }
    public DateTime fechagenerado { get; set; }
    public DateTime fechacanje { get; set; }
    public string premioGanado { get; set; }
    public int premio { get; set; }
    public string estado {  get; set; }
}
