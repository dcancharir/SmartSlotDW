using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClientePromocionViewModel {
    public int id { get; set; }
    public string? cliente { get; set; }
    public string? tipodocumento { get; set; }
    public string? dni {  get; set; }
    public string? categoria { get; set; }
    public List<PromocionesGanadasViewModel> promocionesganadas { get; set; } = new List<PromocionesGanadasViewModel>();
}
