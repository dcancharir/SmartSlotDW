using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClienteCupon {
    public int codsala {  get; set; }
    public int id {  get; set; }
    public int clienteid { get; set; }
    public string? cliente { get; set; }
    //public int sorteoid { get; set; }
    //public int cupones { get; set; }
    //public int cuponescortesia { get; set; }
    public int idSorteo { get; set; }
    public string? nombreSorteo { get; set; }
    public int cuponesGenerados { get; set; }
    public int cuponesAsignados {  get; set; }
    public string? estado {  get; set; }

}
