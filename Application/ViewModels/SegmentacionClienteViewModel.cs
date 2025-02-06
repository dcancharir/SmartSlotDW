using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class SegmentacionClienteViewModel
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public int desde { get; set; }
    public int hasta { get; set; }
}
