using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClientePuntoFechas {
    public int codsala {  get; set; }
    public int id { get; set; }
    public int clienteid { get; set; }
    public string tipoPunto { get; set; }
    public int puntos { get; set; }
    public int saldoactual {  get; set; }
    public DateTime fecha { get; set; }
    public DateTime fechacorta { get; set; }
}
