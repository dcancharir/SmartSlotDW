using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class HistorialCupon {
    public long iddw { get; set; }
    public DateTime fechadw { get; set; }
    public int codsala { get; set; }
    public int clienteid { get; set; }
    public string? cliente { get; set; }
    public int sorteoid { get; set; }
    public string? nombreSorteo { get; set; }
    public DateTime? fecha { get; set; }
    public string? tipoCupon { get; set; }
    public int cupones {  get; set; }
    public string? estadoSorteo { get; set; }
}
