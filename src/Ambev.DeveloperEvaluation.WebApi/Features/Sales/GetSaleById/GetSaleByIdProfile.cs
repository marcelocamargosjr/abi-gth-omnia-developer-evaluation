using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
///     Profile for mapping GetSaleById feature requests and responses.
/// </summary>
public class GetSaleByIdProfile : Profile
{
    public GetSaleByIdProfile()
    {
        CreateMap<GetSaleByIdRequest, GetSaleByIdQuery>();
        CreateMap<GetSaleByIdResult, GetSaleByIdResponse>();
    }
}