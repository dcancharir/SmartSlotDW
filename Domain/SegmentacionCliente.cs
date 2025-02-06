using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class SegmentacionCliente
{
    public int codsala { get; set; }
    public int id { get; set; }
    public string? nombre { get; set; }
    public int desde {  get; set; }
    public int hasta { get; set; }
}
