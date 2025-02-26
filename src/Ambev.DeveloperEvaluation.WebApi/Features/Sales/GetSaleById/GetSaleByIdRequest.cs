using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
///     Request model for retrieving a sale by ID.
/// </summary>
public class GetSaleByIdRequest : IRequest<GetSaleByIdResponse>
{
    /// <summary>
    ///     The unique identifier of the sale to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}