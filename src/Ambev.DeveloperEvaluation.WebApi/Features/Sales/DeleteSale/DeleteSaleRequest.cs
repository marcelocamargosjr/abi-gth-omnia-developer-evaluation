using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
///     Request model for deleting a sale.
/// </summary>
public class DeleteSaleRequest : IRequest<DeleteSaleResponse>
{
    /// <summary>
    ///     The unique identifier of the sale to delete.
    /// </summary>
    public Guid Id { get; set; }
}