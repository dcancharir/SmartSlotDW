using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClienteJugadaMaquinaBGViewModel {
    public string modelo {  get; set; }
    public string juego { get; set; }
    public string serie { get; set; }
    public string tipoMaquina { get; set; }
    public int totalpuntos { get; set; }
    public double residuo { get; set; }
    public string jugadas_calculadas { get; set; }
}
