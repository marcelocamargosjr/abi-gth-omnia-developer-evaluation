using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
///     Handler for processing GetSaleByIdQuery requests.
/// </summary>
public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, GetSaleByIdResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetSaleByIdHandler> _logger;

    /// <summary>
    ///     Initializes a new instance of GetSaleByIdHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="mapper">The AutoMapper instance.</param>
    /// <param name="logger">The logger instance.</param>
    public GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<GetSaleByIdHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    ///     Handles the GetSaleByIdQuery request.
    /// </summary>
    public async Task<GetSaleByIdResult> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing GetSaleByIdQuery for Sale ID: {SaleId}", request.Id);

        var validator = new GetSaleByIdValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for GetSaleByIdQuery: {Errors}", validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
        {
            _logger.LogWarning("Sale with ID {SaleId} not found.", request.Id);
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        }

        _logger.LogInformation("Sale with ID {SaleId} retrieved successfully.", request.Id);

        return _mapper.Map<GetSaleByIdResult>(sale);
    }
}