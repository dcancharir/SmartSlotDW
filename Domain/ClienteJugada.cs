using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class ClienteJugada {
    public int iddw {  get; set; }
    public int codsala {  get; set; }
    public DateTime fechadw {  get; set; }
    public int clienteid { get; set; }
    public string maquina { get; set; }
    public DateTime fecha { get; set; }
    public long clientejugadaMaquinaBGId { get; set; }
    public string clientejugadamaquinabgmodelo { get; set; }
    public string clientejugadamaquinabgjuego { get; set; }
    public string clientejugadamaquinabgserie { get; set; }
    public int clientejugadamaquinabgtotalpuntos { get; set; }
    public double clientejugadamaquinabgresiduo { get; set; }
    public string clientejugadamaquinabgjugadas_calculadas { get; set; }
    public int clientejugadacuponsorteoid { get; set; }
    public int clientejugadacuponcupones { get; set; }
    public double clientejugadacuponresiduo {  get; set; }

}
