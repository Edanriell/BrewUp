using BrewUp.Warehouses.Facade;
using BrewUp.Warehouses.Facade.Endpoints;

namespace BrewUp.Rest.Modules;

public class WarehousesModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 0;

    public IServiceCollection Register(WebApplicationBuilder builder) { return builder.Services.AddWarehouses(); }

    WebApplication IModule.Configure(WebApplication app) { return app.MapWarehousesEndpoints(); }
}