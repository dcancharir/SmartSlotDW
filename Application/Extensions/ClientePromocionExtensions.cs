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
}
