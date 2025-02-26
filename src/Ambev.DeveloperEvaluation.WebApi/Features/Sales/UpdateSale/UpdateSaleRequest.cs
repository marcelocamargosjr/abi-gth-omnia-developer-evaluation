using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
///     Request model for updating an existing sale.
/// </summary>
public class UpdateSaleRequest : IRequest<UpdateSaleResponse>
{
    /// <summary>
    ///     The unique identifier of the sale to update.
    /// </summary>
    public Guid Id { get; set; }

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
    public List<UpdateSaleItemRequest> Items { get; set; } = [];

    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }
}

/// <summary>
///     Represents an item in the sale update request.
/// </summary>
public class UpdateSaleItemRequest
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}