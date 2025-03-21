﻿using Application.CommandsQueries.ClienteCategoriaCQ;
using Application.CommandsQueries.ClienteCQ;
using Application.CommandsQueries.ClienteCuponCQ;
using Application.CommandsQueries.ClientePromocionCQ;
using Application.CommandsQueries.ClientePuntoCQ;
using Application.CommandsQueries.PromocionCQ;
using Application.CommandsQueries.SalaCQ;
using Application.CommandsQueries.SegmentacionClienteCQ;
using Application.CommandsQueries.SorteoCQ;
using Application.CommandsQueries.StatusPlayerCQ;
using Application.ViewModels;
using MediatR;
using Quartz;
using smartslotdwapi.SmartSlotApi;

namespace smartslotdwapi.Jobs;

public class MigracionSinFechas : IJob {
    private readonly IServiceProvider _serviceProvider;
    public MigracionSinFechas(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task Execute(IJobExecutionContext context) {
        using(IServiceScope scope = _serviceProvider.CreateScope()) {
            var _mediator = scope.ServiceProvider.GetService<IMediator>();
            var _logger = scope.ServiceProvider.GetRequiredService<ILogger<MigracionSinFechas>>();
            var salas = await _mediator.Send(new ListarSalasActivasQuery() { });
            foreach(var sala in salas) {
                var uri = sala.uri;
                if(uri == null || uri.Trim().Length == 0) {
                    _logger.LogError($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
                    continue;
                }
                if(uri.Trim().EndsWith("/")) {
                    uri = uri.Trim().Substring(0, uri.Length - 1);
                    sala.uri = uri;
                }
                _logger.LogInformation("Metodo MigrarClientes()");
                await MigrarClientes(_mediator, _logger, sala);
                _logger.LogInformation("Metodo MigrarClienteCategoria()");
                await MigrarClienteCategoria(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarSorteo()");
                await MigrarSorteo(_mediator, _logger, sala);
                _logger.LogInformation("Metodo MigrarClientePromocion()");
                await MigrarClientePromocion(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarSegmentacionCliente()");
                await MigrarSegmentacionCliente(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarPromocion()");
                await MigrarPromocion(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarStatusPlayer()");
                await MigrarStatusPlayer(_mediator, _logger, sala);

                var listaClientes = await _mediator.Send(new ListarClientesQuery() { });
                _logger.LogInformation("Metodo MigrarClienteCupon()");
                await MigrarClienteCupon(_mediator, _logger, sala,listaClientes);
                _logger.LogInformation($"Metodo MigrarClientePunto");
                await MigrarClientePunto(_mediator, _logger, sala,listaClientes);

            }
            _logger.LogInformation($"Finalizado Job MigracionSinFechas");
        }
    }
    private static async Task<bool> MigrarClientes(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<ClienteViewModel>();
            var clientes = api.GetHttpGet($"{sala.uri}/api/Cliente");
            var data = await _mediator.Send(new CrearClienteCommand() { registro = clientes, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClientes() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClienteCategoria(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<ClienteCategoriaViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/ClienteCategoria");
            var data = await _mediator.Send(new CrearClienteCategoriaCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCategoria() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarSorteo(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<SorteoViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/Sorteo");
            var data = await _mediator.Send(new CrearSorteoCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarSorteo() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClientePromocion(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<ClientePromocionViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/ClientePromocion");
            var data = await _mediator.Send(new CrearClientePromocionCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClientePromocion() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarSegmentacionCliente(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<SegmentacionClienteViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/SegmentacionCliente");
            var data = await _mediator.Send(new SegmentacionClienteCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarSegmentacionCliente() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarPromocion(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<PromocionViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/Promocion");
            var data = await _mediator.Send(new PromocionCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarPromocion() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarStatusPlayer(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var api = new SmartSlotApi<StatusPlayerViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/StatusPlayer");
            var data = await _mediator.Send(new StatusPlayerCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarStatusPlayer() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClienteCupon(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala,IEnumerable<ClienteViewModel> clientes) {
        bool respuesta = false;
        try {

            foreach(var item in clientes) {
                var api = new SmartSlotApi<ClienteCuponViewModel>();
                var apiresult = api.GetHttpGet($"{sala.uri}/api/ClienteCupon/cliente/{item.id}");
                var data = await _mediator.Send(new CrearClienteCuponCommand() { registro = apiresult, codsala = sala.codsala });
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCupon() - {ex.Message}");
        }
        return respuesta;
    }
  
    private static async Task<bool> MigrarClientePunto(IMediator _mediator, ILogger<MigracionSinFechas> _logger, SalaViewModel sala,IEnumerable<ClienteViewModel> clientes) {
        bool respuesta = false;
        try {
            foreach(var item in clientes) {
                var api = new SmartSlotApi<ClientePuntoViewModel>();
                var apiresult = api.GetHttpGet($"{sala.uri}/api/ClientePunto/cliente/{item.id}");
                var data = await _mediator.Send(new CrearClientePuntoCommand() { registro = apiresult, codsala = sala.codsala });
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCupon() - {ex.Message}");
        }
        return respuesta;
    }
}
