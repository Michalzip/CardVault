
using System.Reflection;
using CardVault.Shared.Abstraction.Mediator.Commands;
using CardVault.Shared.Abstraction.Postgres;
using CardVault.Shared.Infrastructure.Exceptions;
using CardVault.Shared.Infrastructure.Postgres;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardVault.Shared.Infrastructure;

public static class Extensions
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IList<Assembly> assemblies        
       
    )
    {
        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddErrorHandling();
       
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseRouting(); 
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseErrorHandling();
        return app;
    }

    public static T GetOptions<T>(this IServiceCollection services, string sectionName)
        where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName)
        where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }

}
