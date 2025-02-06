using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Promocion
{
    public int codsala {  get; set; }
    public int id { get; set; }
    public string? nombre { get; set; }
    public DateTime fechaVigenciainicial { get; set; }
    public DateTime fechaVigenciaFinal { get; set; }
    public int estado { get; set; }
}
