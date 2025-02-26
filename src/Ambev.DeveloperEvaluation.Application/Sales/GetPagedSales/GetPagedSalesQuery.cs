using System.Collections.Generic;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Query for retrieving a paginated list of sales.
/// </summary>
public record GetPagedSalesQuery : IRequest<List<GetPagedSalesResult>>
{
    /// <summary>
    ///     Page number for pagination.
    /// </summary>
    public int Page { get; }

    /// <summary>
    ///     Number of items per page.
    /// </summary>
    public int Size { get; }

    /// <summary>
    ///     Ordering of results (e.g., "saleDate desc, totalAmount asc").
    /// </summary>
    public string? Order { get; }

    /// <summary>
    ///     Initializes a new instance of GetPagedSalesQuery.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="size">The number of items per page.</param>
    /// <param name="order">The sorting order.</param>
    public GetPagedSalesQuery(int page, int size, string? order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}