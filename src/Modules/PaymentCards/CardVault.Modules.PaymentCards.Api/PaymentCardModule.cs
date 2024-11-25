using CardVault.Modules.PaymentCards.Application;
using CardVault.Modules.PaymentCards.Application.Abstractions.Data;
using CardVault.Modules.PaymentCards.Domain;
using CardVault.Modules.PaymentCards.Infrastructure;
using CardVault.Modules.PaymentCards.Infrastructure.Context;
using CardVault.Shared.Abstraction.Modules;

namespace CardVault.Modules.PaymentCards.Api;

internal class PaymentCardModule:IModule
{
    public string Name { get; } = "PaymentCards";
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic).ToArray();
        services.AddInfrastructure();
        services.AddApplication(assemblies);
        services.AddDomain();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<PaymentWriteCardsContext>());
      
    }

    public void Use(IApplicationBuilder app)
    {
 
    }
}
