using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class StatusMaquinaCupon
{
    public int codsala {  get; set; }
    public int idDetalle { get; set; }
    public int idCabecera { get; set; }
    public int idSorteo { get; set; }
    public string? sorteo { get; set; }
    public int cupon { get; set; }
}
