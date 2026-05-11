using System;
using ConfigurationExample.Models;

namespace ConfigurationExample.Extensions;

public static class OptionsCollectionExtension
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        // Register the DatabaseOption class as a configuration object.
        // This line must be added before the `builder.Build()` method.
        services.Configure<DatabaseOption>(configuration.GetSection(DatabaseOption.SectionName));
        services.Configure<DatabaseOptions>(
            DatabaseOptions.SystemDatabaseSectionName, 
                configuration.GetSection($"{DatabaseOptions.SectionName}:{DatabaseOptions.SystemDatabaseSectionName}")
            );
        services.Configure<DatabaseOptions>(
            DatabaseOptions.BusinessDatabaseSectionName, 
            configuration.GetSection($"{DatabaseOptions.SectionName}:{DatabaseOptions.BusinessDatabaseSectionName}")
        );

        return services;
    }
}
