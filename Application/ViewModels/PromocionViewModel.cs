using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class PromocionViewModel
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public DateTime fechaVigenciainicial { get; set; }
    public DateTime fechaVigenciaFinal { get; set; }
    public int estado { get; set; }
}
