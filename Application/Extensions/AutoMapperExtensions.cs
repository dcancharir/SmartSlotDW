using Application.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Extensions;
public static class AutoMapperExtensions{
    public static List<ClientePromocion> ToClientePromocionList(
        this IEnumerable<ClientePromocionViewModel> clientesViewModel,
        IMapper mapper) {
        var result = new List<ClientePromocion>();

        foreach(var cliente in clientesViewModel) {
            var clientePromociones = cliente.promocionesganadas
                .Select(promocion => mapper.Map<ClientePromocion>((cliente, promocion)))
                .ToList();

            result.AddRange(clientePromociones);
        }

        return result;
    }
    public static List<ClienteCupon> ToClienteCuponList(
      this IEnumerable<ClienteCuponViewModel> clientesViewModel,
      IMapper mapper) {
        var result = new List<ClienteCupon>();

        foreach(var cliente in clientesViewModel) {
            var clienteCupones = cliente.detallecupones
                .Select(item => mapper.Map<ClienteCupon>((cliente, item)))
                .ToList();

            result.AddRange(clienteCupones);
        }

        return result;
    }
    public static List<ClienteJugada> ToClienteJugadaList(
     this IEnumerable<ClienteJugadaViewModel> clientejugadas,
     IMapper mapper) {
        var result = new List<ClienteJugada>();

        foreach(var cliente in clientejugadas) {
            var item = new ClienteJugada() { 
                clienteid = cliente.clienteid,
                maquina = cliente.maquina,
                fecha = cliente.fecha,
                clientejugadaMaquinaBGId = cliente.clientejugadaMaquinaBGId,
                clientejugadamaquinabgmodelo = cliente.clientejugadamaquinabg.modelo,
                clientejugadamaquinabgjuego = cliente.clientejugadamaquinabg.juego,
                clientejugadamaquinabgserie = cliente.clientejugadamaquinabg.serie,
                clientejugadamaquinabgtotalpuntos=cliente.clientejugadamaquinabg.totalpuntos,
                clientejugadamaquinabgresiduo = cliente.clientejugadamaquinabg.residuo,
                clientejugadamaquinabgjugadas_calculadas = cliente.clientejugadamaquinabg.jugadas_calculadas,
                clientejugadacuponsorteoid = cliente.clientejugadaCupon.sorteoid,
                clientejugadacuponcupones = cliente.clientejugadaCupon.cupones,
                clientejugadacuponresiduo = cliente.clientejugadaCupon.residuo
            };
            //var clienteCupones = cliente.clientejugadamaquinabg
            //    .Select(item => mapper.Map<ClienteCupon>((cliente, item)))
            //    .ToList();

            result.Add(item);
        }

        return result;
    }
}
