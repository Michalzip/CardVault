using System.Runtime.CompilerServices;
using CardVault.Modules.PaymentCards.Domain.PaymentsCards.Repositories;
using CardVault.Modules.PaymentCards.Infrastructure.Context;
using CardVault.Modules.PaymentCards.Infrastructure.PaymentCards.Repositories;
using CardVault.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("CardVault.Modules.PaymentCards.Api")]
namespace CardVault.Modules.PaymentCards.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPostgres<PaymentWriteCardsContext>().AddPostgres<PaymentReadCardsContext>();
        
        services.AddScoped<IPaymentCardRepository, PaymentCardRepository>();
        
        return services;
    }
}