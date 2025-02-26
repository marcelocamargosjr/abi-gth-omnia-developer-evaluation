using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
///     Handler for processing DeleteSaleCommand requests.
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<DeleteSaleHandler> _logger;

    /// <summary>
    ///     Initializes a new instance of DeleteSaleHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    /// <param name="logger">The logger instance.</param>
    public DeleteSaleHandler(ISaleRepository saleRepository, ILogger<DeleteSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _logger = logger;
    }

    /// <summary>
    ///     Handles the DeleteSaleCommand request.
    /// </summary>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
        {
            _logger.LogWarning("Sale with ID {SaleId} not found for deletion.", request.Id);
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        }

        _logger.LogInformation("Sale with ID {SaleId} deleted successfully.", request.Id);
        return new DeleteSaleResponse { Success = true };
    }
}