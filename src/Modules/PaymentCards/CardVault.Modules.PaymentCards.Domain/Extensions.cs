using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("CardVault.Modules.PaymentCards.Api")]

namespace CardVault.Modules.PaymentCards.Domain;

internal static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}
