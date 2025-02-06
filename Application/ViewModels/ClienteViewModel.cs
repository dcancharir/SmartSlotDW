using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;
public class ClienteViewModel {
    public int id { get; set; }
    public string? tipoDocumento { get; set; }
    public string? documento { get; set; }
    public string? categoriacliente { get; set; }
    public string? nombre { get; set; }
    public string? apellidoPaterno { get; set; }
    public string? apellidoMaterno { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public string? correo { get; set; }
    public string? celular { get; set; }
}
