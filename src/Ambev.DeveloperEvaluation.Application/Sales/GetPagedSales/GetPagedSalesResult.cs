using System;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Response model for GetPagedSales operation.
/// </summary>
public class GetPagedSalesResult
{
    /// <summary>
    ///     The unique identifier of the sale.
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
    ///     The total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    ///     The branch where the sale was made.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    ///     The list of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; set; }
}