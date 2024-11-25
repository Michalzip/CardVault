using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CardVault.Modules.PaymentCards.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(moduleAssemblies);

        });
        return services;
    }
}