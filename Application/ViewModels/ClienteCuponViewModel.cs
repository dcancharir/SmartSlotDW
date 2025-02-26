using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClienteCuponViewModel {
    public int id { get; set; }
    public int clienteid { get; set; }
    public string? cliente {  get; set; }
    //public int sorteoid { get; set; }
    //public int cupones { get; set; }
    //public int cuponescortesia { get; set; }
    public List<DetalleCuponesViewModel> detallecupones { get; set; } = new List<DetalleCuponesViewModel>();
}
