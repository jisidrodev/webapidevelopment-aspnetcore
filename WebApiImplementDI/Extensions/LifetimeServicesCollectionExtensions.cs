using System;
using WebApiImplementDI.Services;
using WebApiImplementDI.Services.Interfaces;

namespace WebApiImplementDI.Extensions;

public static class LifetimeServicesCollectionExtensions
{

    public static IServiceCollection AddLifetimeServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService,PostService>();
        services.AddScoped<IScopedService, ScopedService>();
        services.AddSingleton<IDemoService,DemoService>();
        services.AddTransient<ITransientService,TransientService>();
        services.AddSingleton<ISingletonService,SingletonService>();
        services.AddKeyedScoped<IDataService, SqlDatabaseService>("sqlDatabaseService");
        services.AddKeyedScoped<IDataService, CosmosDatabaseService>("cosmosDatabaseService");

        return services;
    }

}
