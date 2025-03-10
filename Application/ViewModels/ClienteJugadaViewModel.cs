using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClienteJugadaViewModel {
    public int clienteid { get; set; }
    public string? maquina { get; set; }
    public DateTime fecha { get; set; }
    public long clientejugadaMaquinaBGId { get; set; }
    public ClienteJugadaMaquinaBGViewModel clientejugadamaquinabg { get; set; } = null!;
    public ClienteJugadaCuponViewModel clientejugadaCupon { get; set; } = null!;
}
