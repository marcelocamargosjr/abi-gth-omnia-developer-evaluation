using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Handler for processing GetPagedSalesQuery requests.
/// </summary>
public class GetPagedSalesHandler : IRequestHandler<GetPagedSalesQuery, List<GetPagedSalesResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPagedSalesHandler> _logger;

    /// <summary>
    ///     Initializes a new instance of GetPagedSalesHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    /// <param name="logger">The logger instance.</param>
    public GetPagedSalesHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetPagedSalesHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Handles the GetPagedSalesQuery request.
    /// </summary>
    public async Task<List<GetPagedSalesResult>> Handle(GetPagedSalesQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetPagedSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for GetPagedSalesQuery: {Errors}", validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        _logger.LogInformation("Fetching sales with pagination. Page: {Page}, Size: {Size}, Order: {Order}",
            request.Page, request.Size, request.Order);

        var sales = await _saleRepository.GetPagedAsync(request.Page, request.Size, request.Order, cancellationToken);

        _logger.LogInformation("Fetched {Count} sales records successfully.", sales.Count());

        return _mapper.Map<List<GetPagedSalesResult>>(sales);
    }
}