using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPagedSales;

/// <summary>
///     Request model for retrieving a paginated list of sales.
/// </summary>
public class GetPagedSalesRequest : IRequest<List<GetPagedSalesResponse>>
{
    /// <summary>
    ///     Page number for pagination.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    ///     Number of items per page.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    ///     Ordering of results (e.g., "saleDate desc, totalAmount asc").
    /// </summary>
    public string? Order { get; set; }
}