using System.Reflection;
using CardVault.Shared.Abstraction.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CardVault.Shared.Infrastructure.Modules;

public static class Extensions
{
    public static IHostBuilder ConfigureModules(this IHostBuilder builder)
        => builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var settings in GetSettings("*")) 
            {
                cfg.AddJsonFile(settings);
            }

            foreach (var settings in
                     GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}")) 
            {
                cfg.AddJsonFile(settings);
            }

            
            IEnumerable<string> GetSettings(string pattern)
                => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                    $"module.{pattern}.json", SearchOption.AllDirectories);
        });


 

   
}