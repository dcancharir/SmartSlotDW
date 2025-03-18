using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class HistorialMigracionDWViewModel {
    public long id { get; set; }
    public DateTime fechamigracion { get; set; }
    public int iniciado { get; set; }
    public int terminado { get; set; }
}
