using BrewUp.Warehouses.SharedKernel.Entities;

namespace BrewUp.Warehouses.Domain;

public static class DomainHelper
{
    internal static Availability MapToSharedDto(this Entities.Availability availability)
    {
        return Availability.Create(availability._beerId, availability._beerName, availability._quantity);
    }
}