using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;

namespace BrewUp.Shared.Entities;

public class SalesOrder : EntityBase
{
    protected SalesOrder() { }

    public string SalesOrderNumber { get; private set; } = new(string.Empty);
    public DateTime OrderDate { get; private set; } = DateTime.MinValue;

    public Guid CustomerId { get; private set; } = Guid.Empty;
    public string CustomerName { get; private set; } = string.Empty;

    public IEnumerable<SalesOrderRowJson> Rows { get; private set; } = Enumerable.Empty<SalesOrderRowJson>();

    public static SalesOrder Create(
        SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, OrderDate orderDate, CustomerId customerId,
        CustomerName customerName, IEnumerable<SalesOrderRowJson> rows)
    {
        return new SalesOrder
        {
            Id = salesOrderId.Value.ToString(),
            SalesOrderNumber = salesOrderNumber.Value,
            OrderDate = orderDate.Value,

            CustomerId = customerId.Value,
            CustomerName = customerName.Value,

            Rows = rows
        };
    }

    public SalesOrderJson ToJson()
    {
        return new SalesOrderJson(Id, SalesOrderNumber, CustomerId, CustomerName, OrderDate, Rows);
    }
}