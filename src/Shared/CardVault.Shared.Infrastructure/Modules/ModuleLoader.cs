﻿using System.Reflection;
using CardVault.Shared.Abstraction.Modules;
using Microsoft.Extensions.Configuration;
namespace CardVault.Shared.Infrastructure.Modules;

public static class ModuleLoader
{

    private const string ModulePartBase = "CardVault.Modules.";


    public static IList<Assembly> LoadAllAssemblies(IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic)
            .ToList(); 
        
        var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
        
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();

        var disabledModules = new List<string>();
        
            foreach (var file in files)
            {
                if (!file.Contains(ModulePartBase))
                {
                    continue;
                }

                var moduleName = file.Split(ModulePartBase)[1].Split(".")[0].ToLowerInvariant();
                var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
                if (!enabled)
                {
                    disabledModules.Add(file);
                }
            }

            foreach (var disabledModule in disabledModules)
            {
                files.Remove(disabledModule);
            }
            
            files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

            return assemblies;
    }

    public static IList<Assembly> LoadAssemblies(IConfiguration configuration, string modulePart)
    {
        
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(x => !x.IsDynamic).Select(x => x.Location).ToArray();
      
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(x => !locations.Contains(x, StringComparer.InvariantCultureIgnoreCase))
            .ToList();
        
        var disabledModules = new List<string>();
        
        foreach (var file in files)
        {
            if (!file.Contains(modulePart))
            {
                continue;
            }

            var moduleName = file.Split(modulePart)[1].Split(".")[0].ToLowerInvariant();
            var enabled = configuration.GetValue<bool>($"{moduleName}:module:enabled");
            if (!enabled)
            {
                disabledModules.Add(file);
            }
        }

        foreach (var disabledModule in disabledModules)
        {
            files.Remove(disabledModule);
        }

        files.ForEach(x => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x))));

        return assemblies;
    }
    
    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .OrderBy(x => x.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
}

