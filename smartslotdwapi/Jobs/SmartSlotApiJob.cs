using MediatR;
using Quartz;
using Application.CommandsQueries.ClienteCQ;
using Application.ViewModels;
using Newtonsoft.Json;
using smartslotdwapi.SmartSlotApi;
using Application.CommandsQueries.SalaCQ;
using Application.CommandsQueries.ClienteCategoriaCQ;
using Application.CommandsQueries.ClienteCuponCQ;
using Application.CommandsQueries.ClientePromocionCQ;
using Application.CommandsQueries.AfluenciaHoraCQ;
using Application.CommandsQueries.StatusPlayerCQ;
using Application.CommandsQueries.PromocionCQ;
using Application.CommandsQueries.SegmentacionClienteCQ;
namespace smartslotdwapi.Jobs;

public class SmartSlotApiJob : IJob {
    private readonly IServiceProvider _serviceProvider;
    public SmartSlotApiJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task Execute(IJobExecutionContext context) {
        using (IServiceScope scope = _serviceProvider.CreateScope()) {
            var _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var _logger = scope.ServiceProvider.GetRequiredService<ILogger<SmartSlotApiJob>>();
            _logger.LogInformation("inicio del job");
            var salas = await _mediator.Send(new ListarSalasActivasQuery() { });
            foreach(var sala in salas) {
                _logger.LogInformation("Metodo MigrarClientes()");
                await MigrarClientes(_mediator, _logger, sala);
                _logger.LogInformation("Metodo MigrarClienteCategoria()");
                await MigrarClienteCategoria(_mediator, _logger, sala);
                _logger.LogInformation("Metodo MigrarClienteCupon()");
                await MigrarClienteCupon(_mediator, _logger, sala);
                _logger.LogInformation("Metodo MigrarClientePromocion()");
                await MigrarClientePromocion(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarAfluenciaHora()");
                await MigrarAfluenciaHora(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarStatusPlayer()");
                await MigrarStatusPlayer(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarPromocion()");
                await MigrarPromocion(_mediator, _logger, sala);
                _logger.LogInformation($"Metodo MigrarSegmentacionCliente()");
                await MigrarSegmentacionCliente(_mediator, _logger, sala);
            }
            _logger.LogInformation("Job Finalizado");
        }
    }
    private static async Task<bool> MigrarClientes(IMediator _mediator,ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var uri = sala.uri;
            if (uri == null||uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/")) {
                uri=uri.Trim().Substring(0, uri.Length - 1);
            }
            
            var api = new SmartSlotApi<ClienteViewModel>();
            var clientes = api.GetHttpGet($"{uri}/api/Cliente");
            var data = await _mediator.Send(new CrearClienteCommand() { registro = clientes, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex) {
            _logger.LogError($"Error metodo MigrarClientes() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClienteCategoria(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/")) {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<ClienteCategoriaViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/ClienteCategoria");
            var data = await _mediator.Send(new CrearClienteCategoriaCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCategoria() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClienteCupon(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/")) {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<ClienteCuponViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/ClienteCupon");
            var data = await _mediator.Send(new CrearClienteCuponCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCupon() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClientePromocion(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/")) {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<ClientePromocionViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/ClientePromocion");
            var data = await _mediator.Send(new CrearClientePromocionCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex) {
            _logger.LogError($"Error metodo MigrarClientePromocion() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarAfluenciaHora(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala)
    {
        bool respuesta = false;
        try
        {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/"))
            {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<AfluenciaHoraViewModel>();
            var fechaActual = DateTime.Now.AddDays(-1);
            var fechaIni = fechaActual.ToString("yyyy-MM-dd 00:00:00");
            var fechafin = fechaActual.ToString("yyyy-MM-dd 23:59:59");
            var apiresult = api.GetHttpGet($"{uri}/api/AfluenciaHora/{fechaIni}/{fechafin}");
            var data = await _mediator.Send(new CrearAfluenciaHoraCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error metodo MigrarAfluenciaHora() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarStatusPlayer(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala)
    {
        bool respuesta = false;
        try
        {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/"))
            {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<StatusPlayerViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/StatusPlayer");
            var data = await _mediator.Send(new StatusPlayerCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error metodo MigrarStatusPlayer() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarPromocion(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala)
    {
        bool respuesta = false;
        try
        {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/"))
            {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<PromocionViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/StatusPlayer");
            var data = await _mediator.Send(new PromocionCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error metodo MigrarPromocion() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarSegmentacionCliente(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala)
    {
        bool respuesta = false;
        try
        {
            var uri = sala.uri;
            if (uri == null || uri.Trim().Length == 0) throw new Exception($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
            if (uri.Trim().EndsWith("/"))
            {
                uri = uri.Trim().Substring(0, uri.Length - 1);
            }

            var api = new SmartSlotApi<SegmentacionClienteViewModel>();
            var apiresult = api.GetHttpGet($"{uri}/api/SegmentacionCliente");
            var data = await _mediator.Send(new SegmentacionClienteCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error metodo MigrarSegmentacionCliente() - {ex.Message}");
        }
        return respuesta;
    }
}
