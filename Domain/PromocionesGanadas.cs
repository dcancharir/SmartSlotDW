using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class PromocionesGanadas {
    public int idPromocion { get; set; }
    public string promocion { get; set; }
    public string tipopromocion { get; set; }
    public DateTime fechagenerado { get; set; }
    public DateTime fechacanje { get; set; }
    public string premioGanado { get; set; }
    public int premio { get; set; }
    public string estado { get; set; }
}
