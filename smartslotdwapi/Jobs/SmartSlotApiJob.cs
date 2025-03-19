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
using Application.CommandsQueries.SorteoCQ;
using Application.CommandsQueries.ClientePuntoCQ;
using Application.CommandsQueries.ClientePuntoFechasCQ;
using Application.CommandsQueries.HistorialCuponCQ;
using Application.CommandsQueries.ClienteJugadaCQ;
using Application.CommandsQueries.CanjeProductoCQ;
using Domain;
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
                var uri = sala.uri;
                if (uri == null || uri.Trim().Length == 0)
                {
                    _logger.LogError($"No se encontro la uri para la sala : {sala.codsala} - {sala.nombre}");
                    continue;
                }
                if (uri.Trim().EndsWith("/"))
                {
                    uri = uri.Trim().Substring(0, uri.Length - 1);
                    sala.uri = uri;
                }
      
                //_logger.LogInformation("Obteniendo lista de clientes");
                //var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });
          
                //_logger.LogInformation("Obteniendo lista de sorteos");
                //var sorteos = await _mediator.Send(new ListarSorteosQuery() { codsala = sala.codsala });
                //sorteos = sorteos.Where(x => x.estado == "Vigente");
                
             
                //_logger.LogInformation("Metodo MigrarClienteCupon()");
                //await MigrarClienteCupon(_mediator, _logger, sala);
            
                //_logger.LogInformation($"Metodo MigrarAfluenciaHora()");
                //await MigrarAfluenciaHora(_mediator, _logger, sala);
                //_logger.LogInformation($"Metodo MigrarStatusPlayer()");
                //await MigrarStatusPlayer(_mediator, _logger, sala);
           

                //_logger.LogInformation($"Metodo MigrarClientePunto");
                //await MigrarClientePunto(_mediator, _logger, sala);
                //_logger.LogInformation($"Metodo MigrarClientePuntoFechas");
                //await MigrarClientePuntoFechas(_mediator, _logger, sala);
                //_logger.LogInformation($"Metodo MigrarHistorialCupon");
                //await MigrarHistorialCupon(_mediator, _logger, sala,clientes);
                _logger.LogInformation(@"Metodo CanjeProducto");
                await MigrarCanjeProducto(_mediator, _logger,sala); 
                //_logger.LogInformation(@"Metodo MigrarClienteJugada");
                //await MigrarClienteJugada(_mediator, _logger,sala, clientes,sorteos);
            }
            _logger.LogInformation("Job Finalizado");
        }
    }
   
   
    private static async Task<bool> MigrarClienteCupon(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });
         
            foreach(var item in clientes) {
                var api = new SmartSlotApi<ClienteCuponViewModel>();
                var apiresult = api.GetHttpGet($"{sala.uri}/api/ClienteCupon/cliente/{item.id}");
                var data = await _mediator.Send(new CrearClienteCuponCommand() { registro = apiresult, codsala = sala.codsala });
            }
            respuesta = true;
        }
        catch (Exception ex) {
            _logger.LogError($"Error metodo MigrarClienteCupon() - {ex.Message}");
        }
        return respuesta;
    }
  
    private static async Task<bool> MigrarAfluenciaHora(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala)
    {
        bool respuesta = false;
        try
        {
            var api = new SmartSlotApi<AfluenciaHoraViewModel>();
            var fechaActual = DateTime.Now.AddDays(-1);
            var fechaIni = fechaActual.ToString("yyyy-MM-dd 00:00:00");
            var fechafin = fechaActual.ToString("yyyy-MM-dd 23:59:59");
            var apiresult = api.GetHttpGet($"{sala.uri}/api/AfluenciaHora/{fechaIni}/{fechafin}");
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
            var api = new SmartSlotApi<StatusPlayerViewModel>();
            var apiresult = api.GetHttpGet($"{sala.uri}/api/StatusPlayer");
            var data = await _mediator.Send(new StatusPlayerCommand() { registro = apiresult, codsala = sala.codsala });
            respuesta = true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error metodo MigrarStatusPlayer() - {ex.Message}");
        }
        return respuesta;
    }
   
    
    private static async Task<bool> MigrarClientePunto(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });

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
    private static async Task<bool> MigrarClientePuntoFechas(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });

            foreach(var item in clientes) {
                var api = new SmartSlotApi<ClientePuntoFechasViewModel>();
                var fechaActual = DateTime.Now.AddDays(-1);
                var fechaIni = fechaActual.ToString("yyyy-MM-dd");
                var fechafin = fechaActual.ToString("yyyy-MM-dd");
                var apiresult = api.GetHttpGet($"{sala.uri}/api/ClientePunto/clientefechas/{item.id}/{fechaIni}/{fechafin}");
                var data = await _mediator.Send(new CrearClientePuntoFechasCommand() { registro = apiresult, codsala = sala.codsala });
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarClientePuntoFechas() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarHistorialCupon(
        IMediator _mediator, 
        ILogger<SmartSlotApiJob> _logger, 
        SalaViewModel sala,
        IEnumerable<ClienteViewModel> clientes
    ) {
        bool respuesta = false;
        try {
            //var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });
            var fechaActual = DateTime.Now;
            var fechaOperacion = fechaActual.AddDays(-1);
            var fechaIni = fechaOperacion.ToString("yyyy-MM-dd");
            var fechafin = fechaActual.ToString("yyyy-MM-dd");
            await _mediator.Send(new RemoveHistorialCuponCommand() { codsala = sala.codsala, fechaOperacion = fechaOperacion });
            foreach(var item in clientes) {
                var api = new SmartSlotApi<HistorialCuponViewModel>();
                var apiresult = api.GetHttpGet($"{sala.uri}/api/ClienteCupon/historialcupon/{item.id}/{fechaIni}/{fechafin}");
                var data = await _mediator.Send(new CrearHistorialCuponCommand() { registro = apiresult, codsala = sala.codsala , fechaOperacion = fechaOperacion });
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarHistorialCupon() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarClienteJugada(
       IMediator _mediator,
       ILogger<SmartSlotApiJob> _logger,
       SalaViewModel sala,
       IEnumerable<ClienteViewModel> clientes,
       IEnumerable<SorteoViewModel> sorteos
    ) {
        bool respuesta = false;
        try {
            var fechaActual = DateTime.Now;
            var fechaOperacion = fechaActual.AddDays(-1);
            var fechaIni = fechaOperacion.ToString("yyyy-MM-dd");
            var fechafin = fechaActual.ToString("yyyy-MM-dd");
            await _mediator.Send(new RemoveClienteJugadaCommand() { codsala = sala.codsala, fechaOperacion = fechaOperacion });
            foreach(var item in clientes) {
                foreach(var sorteo in sorteos) {
                   
                    var api = new SmartSlotApi<ClienteJugadaViewModel>();
                    var apiresult = api.GetHttpGet($"{sala.uri}/api/ClienteJugada/Top/{item.id}/{fechaIni}/{fechafin}/{sorteo.id}");
                    _logger.LogInformation($"Cliente : {item.nombre} - IdSorteo : {sorteo.id} - TotalJugadas : {apiresult.Count}");
                    if(apiresult.Count>0) {
                        var data = await _mediator.Send(new CrearClienteJugadaCommand() { registro = apiresult, codsala = sala.codsala, fechaOperacion = fechaOperacion });
                    }
                }
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarHistorialCupon() - {ex.Message}");
        }
        return respuesta;
    }
    private static async Task<bool> MigrarCanjeProducto(IMediator _mediator, ILogger<SmartSlotApiJob> _logger, SalaViewModel sala) {
        bool respuesta = false;
        try {
            var clientes = await _mediator.Send(new ListarClientesQuery() { codsala = sala.codsala });
            var fechaActual = DateTime.Now.AddDays(-1);
            var fechaIni = fechaActual.AddDays(-1).ToString("yyyy-MM-dd");
            var fechafin = fechaActual.ToString("yyyy-MM-dd");
            foreach(var item in clientes) {
                var api = new SmartSlotApi<CanjeProductoViewModel>();
           
                var apiresult = api.GetHttpGet($"{sala.uri}/api/CanjeProducto/GetCanjeProductooByParameters/{fechaIni}/{fechafin}/{item.id}");
                _logger.LogInformation($"Cliente : {item.id}-{item.nombre} - TotalRegistros : {apiresult.Count}");
                if(apiresult.Count > 0) { 
                    var data = await _mediator.Send(new CrearCanjeProductoCommand() { registro = apiresult, codsala = sala.codsala });
                }
            }
            respuesta = true;
        } catch(Exception ex) {
            _logger.LogError($"Error metodo MigrarCanjeProducto() - {ex.Message}");
        }
        return respuesta;
    }
}
