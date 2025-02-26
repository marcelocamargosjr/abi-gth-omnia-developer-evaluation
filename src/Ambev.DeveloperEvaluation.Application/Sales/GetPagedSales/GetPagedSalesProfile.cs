using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Profile for mapping between Sale entity and GetPagedSalesResult.
/// </summary>
public class GetPagedSalesProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for GetPagedSales operation.
    /// </summary>
    public GetPagedSalesProfile()
    {
        CreateMap<Sale, GetPagedSalesResult>();
    }
}