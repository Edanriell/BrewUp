using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainModel;

namespace BrewUp.Warehouses.SharedKernel.Entities;

public class Availability : EntityBase
{
    protected Availability() { }

    private Availability(string beerId, string beerName, Quantity quantity)
    {
        Id = beerId;

        BeerId = beerId;
        BeerName = beerName;
        Quantity = quantity;
    }

    public string BeerId { get; set; } = string.Empty;
    public string BeerName { get; set; } = string.Empty;

    public Quantity Quantity { get; set; } = new(0, string.Empty);

    public static Availability Create(BeerId beerId, BeerName beerName, Quantity quantity)
    {
        return new Availability(beerId.Value.ToString(), beerName.Value, quantity);
    }

    public BeerAvailabilityJson ToJson()
    {
        return new BeerAvailabilityJson(Id, BeerName,
            new Shared.CustomTypes.Availability(0, Quantity.Value, Quantity.UnitOfMeasure));
    }
}