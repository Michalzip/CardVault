using CardVault.Shared.Abstraction.Modules;
using CardVault.Shared.Infrastructure.Modules;

namespace CardVault.Bootstrapper;

public static class Extensions
{ 
    public static IEnumerable<IModule> LoadAndRegisterModules(this WebApplicationBuilder builder)
    {
        var assemblies = ModuleLoader.LoadAllAssemblies(builder.Configuration);
        var modules = ModuleLoader.LoadModules(assemblies);

        foreach (var module in modules)
        {
            module.Register(builder.Services, builder.Configuration);
        }

        return modules;
    }

    public static void UseModules(this WebApplication app, IEnumerable<IModule> modules)
    {
        foreach (var module in modules)
        {
            module.Use(app);
        }
    }
    
}
