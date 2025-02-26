using Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPagedSales;

/// <summary>
///     Profile for mapping GetPagedSales feature requests and responses.
/// </summary>
public class GetPagedSalesProfile : Profile
{
    public GetPagedSalesProfile()
    {
        CreateMap<GetPagedSalesRequest, GetPagedSalesQuery>();
        CreateMap<GetPagedSalesResult, GetPagedSalesResponse>();
    }
}