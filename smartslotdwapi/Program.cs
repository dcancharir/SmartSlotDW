using Application;
using Persistence;
using Quartz;
using Serilog;
using smartslotdwapi.Jobs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence();
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.Limits.MaxRequestBodySize = long.MaxValue;
});
builder.Host.ConfigureLogging(logging => {
    var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
    if (!Directory.Exists(logFolder)) {
        Directory.CreateDirectory(logFolder);
    }

    var logFile = Path.Combine(logFolder, "smartslotdw-.log");
    logging.AddSerilog();
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Error)
        .WriteTo.File(logFile, rollingInterval: RollingInterval.Day)
        .CreateLogger();
});
var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
/*Quartz*/
builder.Services.AddQuartz(q => {
    ////base Quartz scheduler, job and trigger configurations
    //if (true) {
    //    JobKey key = new JobKey("SmartSlotApiJob");
    //    q.AddJob<SmartSlotApiJob>(jobConfig => jobConfig.WithIdentity(key));
    //    q.AddTrigger(opts => opts
    //            .ForJob(key)
    //            .WithIdentity("SmartSlotApiJob-trigger")
    //            .WithSimpleSchedule(x => x
    //                .WithIntervalInHours(1)
    //                .RepeatForever().Build())
    //            .StartNow()
    //    );
    //}
    //if(true) {
    //    JobKey key = new JobKey("CreateFechaHistorialMigracionJob");
    //    q.AddJob<CreateFechaHistorialMigracionJob>(jobConfig => jobConfig.WithIdentity(key));
    //    q.AddTrigger(opts => opts
    //            .ForJob(key)
    //            .WithIdentity("CreateFechaHistorialMigracionJob-trigger")
    //            .WithSimpleSchedule(x => x
    //                .WithIntervalInHours(1)
    //                .RepeatForever().Build())
    //            .StartNow()
    //    );
    //}
    if(true) {
        JobKey key = new JobKey("MigracionSinFechas");
        q.AddJob<MigracionSinFechas>(jobConfig => jobConfig.WithIdentity(key));
        q.AddTrigger(opts => opts
                .ForJob(key)
                .WithIdentity("MigracionSinFechas-trigger")
                .WithSimpleSchedule(x => x
                    .WithIntervalInHours(1)
                    .RepeatForever().Build())
                .StartNow()
        );
    }
}).AddQuartzHostedService(options => {
    // when shutting down we want jobs to complete gracefully
    options.WaitForJobsToComplete = true;
});
/*EndQuartz*/
var app = builder.Build();
app.Lifetime.ApplicationStarted.Register(() => {
    logger.LogInformation("La aplicacion se ha iniciado");
});
app.Lifetime.ApplicationStopping.Register(() => Console.WriteLine("La aplicación está deteniéndose."));
app.Lifetime.ApplicationStopped.Register(() => Console.WriteLine("La aplicación ha sido detenida."));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
