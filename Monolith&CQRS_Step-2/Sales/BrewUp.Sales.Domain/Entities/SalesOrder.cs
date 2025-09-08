using BrewUp.Sales.SharedKernel.CustomTypes;
using BrewUp.Shared.Contracts;
using BrewUp.Shared.CustomTypes;
using BrewUp.Shared.DomainModel;

namespace BrewUp.Sales.Domain.Entities;

public class SalesOrder : AggregateRoot
{
    internal readonly CustomerId _customerId;
    internal readonly CustomerName _customerName;
    internal readonly OrderDate _orderDate;

    internal readonly IEnumerable<SalesOrderRow> _rows;
    internal readonly SalesOrderId _salesOrderId;
    internal readonly SalesOrderNumber _salesOrderNumber;

    protected SalesOrder() { }

    private SalesOrder(
        SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber, OrderDate orderDate,
        CustomerId customerId, CustomerName customerName, IEnumerable<SalesOrderRow> row)
    {
        _salesOrderId = salesOrderId;
        _salesOrderNumber = salesOrderNumber;
        _orderDate = orderDate;

        _customerId = customerId;
        _customerName = customerName;

        _rows = row;
    }

    internal static SalesOrder CreateSalesOrder(
        SalesOrderId salesOrderId, SalesOrderNumber salesOrderNumber,
        OrderDate orderDate, CustomerId customerId, CustomerName customerName, IEnumerable<SalesOrderRowJson> rows)
    {
        return new SalesOrder(salesOrderId, salesOrderNumber, orderDate, customerId, customerName,
            rows.MapToDomainRows());
    }
}