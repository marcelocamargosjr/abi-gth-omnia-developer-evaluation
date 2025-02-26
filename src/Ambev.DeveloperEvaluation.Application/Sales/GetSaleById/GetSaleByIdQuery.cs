using System;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
///     Query for retrieving a sale by ID.
/// </summary>
public record GetSaleByIdQuery : IRequest<GetSaleByIdResult>
{
    /// <summary>
    ///     The unique identifier of the sale to retrieve.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Initializes a new instance of GetSaleByIdQuery.
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve.</param>
    public GetSaleByIdQuery(Guid id)
    {
        Id = id;
    }
}