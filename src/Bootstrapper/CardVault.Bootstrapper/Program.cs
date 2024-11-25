using System.Reflection.Metadata;
using CardVault.Bootstrapper;
using CardVault.Shared.Infrastructure;
using CardVault.Shared.Infrastructure.Endpoints;
using CardVault.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();
var modules = builder.LoadAndRegisterModules();
builder.Services.AddControllers();
builder.Services.AddEndpoints();
var assemblies = ModuleLoader.LoadAllAssemblies(builder.Configuration);
builder.Services.AddInfrastructure(assemblies);

var app = builder.Build();
app.UseModules(modules);
app.UseInfrastructure();
app.MapControllers();
app.MapEndpoints();
app.Run();




