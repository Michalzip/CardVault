using CardVault.Shared.Abstraction.Mediator.Commands;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace CardVault.Shared.Infrastructure.Postgres;

public static  class Extensions
{
    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>("ConnectionStrings");
        services.AddDbContext<T>(x => x.UseNpgsql(options.Postgres));
        
        //allow us to communcate with other methods like dapper for exemaple.. 
        NpgsqlDataSource npgsqlDataSource = new NpgsqlDataSourceBuilder(options.Postgres).Build();
        services.TryAddSingleton(npgsqlDataSource);
     
        
        return services;
    }
    
    
}