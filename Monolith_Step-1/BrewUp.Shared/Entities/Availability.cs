using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;

namespace BrewUp.Shared.Entities;

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

    public string BeerId { get; private set; } = string.Empty;
    public string BeerName { get; } = string.Empty;

    public Quantity Quantity { get; } = new(0, string.Empty);

    public static Availability Create(BeerId beerId, BeerName beerName, Quantity quantity)
    {
        return new Availability(beerId.Value.ToString(), beerName.Value, quantity);
    }

    public BeerAvailabilityJson ToJson()
    {
        return new BeerAvailabilityJson(Id, BeerName,
            new CustomTypes.Availability(0, Quantity.Value, Quantity.UnitOfMeasure));
    }
}