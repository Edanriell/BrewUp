using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainModel;
using Microsoft.Extensions.DependencyInjection;
using Availability = BrewUp.Warehouses.Domain.Entities.Availability;

namespace BrewUp.Warehouses.Domain;

public sealed class WarehousesDomainService([FromKeyedServices("warehouses")] IRepository repository)
    : IWarehousesDomainService
{
    public async Task UpdateAvailabilityDueToProductionOrderAsync(
        BeerId beerId, BeerName beerName, Quantity quantity,
        CancellationToken cancellationToken)
    {
        var aggregate = Availability.CreateAvailability(beerId, beerName, quantity);
        await repository.InsertAsync(aggregate.MapToSharedDto(), cancellationToken);
    }
}