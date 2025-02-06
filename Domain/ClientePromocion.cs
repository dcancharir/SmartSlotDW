using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClientePromocion {
    public int codsala { get; set; }
    public int id { get; set; }
    public int promocionsalaid { get; set; }
    public int clienteid { get; set; }
    public int tipoPremio { get; set; }
    public int categoriaPremio { get; set; }
    public int premio { get; set; }
    public string? tipoPremioStr { get; set; }
    public string? categoriaPremioStr { get; set; }
}
