using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class DetalleCuponesViewModel {
    public int idSorteo {  get; set; }
    public string? nombreSorteo { get; set; }
    public int cuponesGenerados { get; set; }
    public int cuponesAsignados { get; set; }
    public string? estado { get; set; }
}
