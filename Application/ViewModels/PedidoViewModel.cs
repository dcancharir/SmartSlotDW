using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class PedidoViewModel {
    public string producto { get; set; }
    public string categoriaProducto { get; set; }
    public int cantidad_pedida { get; set; }
}
