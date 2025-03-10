using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class SorteoViewModel {
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? descripcion { get; set; }
    public DateTime fechaInicioSorteo { get; set; }
    public DateTime fechaFinSorteo { get; set; }
    public string? estado { get; set; }
    public string? tipo { get; set; }
    public List<SorteoConfiguracionViewModel> listaSorteoConfiguracion { get; set; } = new List<SorteoConfiguracionViewModel>();
}
