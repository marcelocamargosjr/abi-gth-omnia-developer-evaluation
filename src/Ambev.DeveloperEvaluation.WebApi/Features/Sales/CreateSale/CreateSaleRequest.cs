namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
///     Request model for creating a new sale.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    ///     The sale number.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    ///     The date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    ///     The customer ID associated with the sale.
    /// </summary>
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    ///     The branch where the sale was made.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    ///     The list of items included in the sale.
    /// </summary>
    public List<CreateSaleItemRequest> Items { get; set; } = [];
}

/// <summary>
///     Represents an item in the sale request.
/// </summary>
public class CreateSaleItemRequest
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}