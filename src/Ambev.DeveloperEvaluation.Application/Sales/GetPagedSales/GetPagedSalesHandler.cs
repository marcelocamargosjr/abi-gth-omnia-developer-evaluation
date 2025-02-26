using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Handler for processing GetPagedSalesQuery requests.
/// </summary>
public class GetPagedSalesHandler : IRequestHandler<GetPagedSalesQuery, List<GetPagedSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    ///     Initializes a new instance of GetPagedSalesHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    public GetPagedSalesHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    /// <summary>
    ///     Handles the GetPagedSalesQuery request.
    /// </summary>
    public async Task<List<GetPagedSalesResult>> Handle(GetPagedSalesQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetPagedSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sales = await _saleRepository.GetPagedAsync(request.Page, request.Size, request.Order, cancellationToken);
        return _mapper.Map<List<GetPagedSalesResult>>(sales);
    }
}