using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClientePuntoFechasViewModel {
    public int clienteid { get; set; }
    public string tipoPunto { get; set; }
    public int puntos { get; set; }
    public int saldoactual { get; set; }
    public DateTime fecha { get; set; }
}
