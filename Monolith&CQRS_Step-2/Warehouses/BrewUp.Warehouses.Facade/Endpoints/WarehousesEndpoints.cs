﻿using BrewUp.Warehouses.Facade.Validators;
using BrewUp.Warehouses.SharedKernel.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BrewUp.Warehouses.Facade.Endpoints;

public static class WarehousesEndpoints
{
    public static WebApplication MapWarehousesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/v1/wareHouses/")
            .WithTags("Warehouses");

        group.MapPost("/availabilities", HandleSetAvailabilities)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status201Created)
            .WithName("SetAvailabilities");

        return app;
    }

    public static async Task<IResult> HandleSetAvailabilities(
        IWarehousesFacade warehousesFacade,
        IValidator<SetAvailabilityJson> validator,
        ValidationHandler validationHandler,
        SetAvailabilityJson body,
        CancellationToken cancellationToken)
    {
        await warehousesFacade.SetAvailabilityAsync(body, cancellationToken);

        return Results.Created();
    }
}