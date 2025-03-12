using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class Pedido {
    public int iddw {  get; set; }
    public int canjeproductoid { get; set; }
    public int codsala {  get; set; }
    public string producto { get; set; }
    public string categoriaProducto { get; set; }
    public int cantidad_pedida {  get; set; }
}
