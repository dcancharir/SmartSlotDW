using Application.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistence;
public static class DependencyInjection {
    public static void AddPersistence(this IServiceCollection services) {
        services.AddSingleton<DapperContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IClienteRepository,ClienteRepository>();
        services.AddScoped<ISalaRepository, SalaRepository>();
        services.AddScoped<IClienteCategoriaRepository,ClienteCategoriaRepository>();
        services.AddScoped<IClienteCuponRepository,ClienteCuponRepository>();
        services.AddScoped<IClientePromocionRepository, ClientePromocionRepository>();
        services.AddScoped<IAfluenciaHoraRepository, AfluenciaHoraRepository>();
        services.AddScoped<IStatusPlayerRepository, StatusPlayerRepository>();
        services.AddScoped<IStatusMaquinaCuponRepository ,StatusMaquinaCuponRepository>();
        services.AddScoped<IPromocionRepository, PromocionRepository>();
        services.AddScoped<ISegmentacionClienteRepository, SegmentacionClienteRepository>();
    }
}
