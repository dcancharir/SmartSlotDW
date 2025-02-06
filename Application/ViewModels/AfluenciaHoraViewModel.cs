using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class AfluenciaHoraViewModel
{
    public int hora { get; set; }
    public int cantJuego { get; set; }
    public DateTime fechajuego { get; set; }
    public double produccion { get; set; }
    public int totalPuntos { get; set; }
    public int cantclientes { get; set; }
    public string? maquina { get; set; }
}
