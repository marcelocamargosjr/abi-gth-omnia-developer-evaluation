using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
///     Represents the response returned after successfully updating a sale.
/// </summary>
public class UpdateSaleResult
{
    /// <summary>
    ///     Gets or sets the unique identifier of the updated sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Gets or sets the sale number.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    ///     Gets or sets the customer ID associated with the sale.
    /// </summary>
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the total sale amount after processing items.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    ///     Gets or sets the branch where the sale was made.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the list of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }
}