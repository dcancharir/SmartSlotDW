using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClientePunto {
    public int codsala {  get; set; }
    public int id {  get; set; }
    public int clienteid { get; set; }
    public int totalpuntos { get; set; }
    public int puntos {  set; get; }
    public int puntoCortesia { get; set; }
    public int puntoCortesiaNC { get; set; }
}
