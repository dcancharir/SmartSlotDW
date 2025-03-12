using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class CanjeProducto {
    public int iddw {  get; set; }
    public int id {  get; set; }
    public int codsala { get; set; }
    public string comprobante { get; set; }
    public string tipodocumento { get; set; }
    public string documento { get; set; }
    public string apellidoPaterno { get; set; }
    public string apellidoMaterno { get; set; }
    public string nombres { get; set; }
    public string categoriaCliente { get; set; }
    public int puntos_canjeados { get; set; }
    public string estado { get; set; }
    public DateTime fechaPedido { get; set; }
    public List<Pedido> pedido { get; set; } = new List<Pedido>();
}
