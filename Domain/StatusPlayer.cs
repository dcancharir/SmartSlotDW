using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class StatusPlayer
{
    public int codsala {  get; set; }
    public int idStatus { get; set; }
    public string? nombrecompleto { get; set; }
    public string? dni { get; set; }
    public string? maquina { get; set; }
    public DateTime fechaini { get; set; }
    public DateTime fechafin { get; set; }
    public double token { get; set; }
    public int puntos { get; set; }
    public int coinin { get; set; }
    public int coinout { get; set; }
    public int jackpot { get; set; }
    public int clienteid { get; set; }
    public int bill_ini { get; set; }
    public int bill_fin { get; set; }
    public List<StatusMaquinaCupon> statusMaquinaCupon { get; set; } = null!;
}
