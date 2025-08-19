using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;
using System.Text.Json;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using Xunit;

namespace BrewUp.Rest.Tests;

[ExcludeFromCodeCoverage]
[Collection("Integration Fixture")]
public class SalesTests(AppHttpClientFixture integrationFixture)
{
    [Fact]
    public async Task Can_Create_SalesOrder()
    {
        var now = DateTime.UtcNow;
        SalesOrderJson body = new(Guid.NewGuid().ToString(),
            $"{now.Year:0000}{now.Month:00}{now.Day:00}-{now.Hour:00}{now.Minute:00}",
            Guid.NewGuid(), "Customer",
            now, new List<SalesOrderRowJson>
            {
                new()
                {
                    BeerId = Guid.NewGuid(),
                    BeerName = "BrewUp IPA",
                    Quantity = new Quantity(10, "Lt"),
                    Price = new Price(5, "EUR")
                }
            });

        var stringJson = JsonSerializer.Serialize(body);
        var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");
        var postResult = await integrationFixture.Client.PostAsync("/v1/sales", httpContent);

        Assert.Equal(HttpStatusCode.Created, postResult.StatusCode);
    }
}