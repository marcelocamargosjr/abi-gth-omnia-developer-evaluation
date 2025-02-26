using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
///     Represents an individual item in a sale transaction.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    ///     Product ID associated with this sale item.
    /// </summary>
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    ///     Quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    ///     Unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    ///     Discount applied to the item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    ///     Total amount BEFORE discount.
    /// </summary>
    public decimal TotalAmount { get; set; }
}