using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
///     Handler for processing UpdateSaleCommand requests.
/// </summary>
public class UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<UpdateSaleHandler> logger)
    : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    /// <summary>
    ///     Handles the UpdateSaleCommand request.
    /// </summary>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing UpdateSaleCommand for Sale ID: {SaleId}", command.Id);

        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            logger.LogWarning("Validation failed for UpdateSaleCommand: {Errors}", validationResult.Errors);
            throw new ValidationException(validationResult.Errors);
        }

        var existingSale = await saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale == null)
        {
            logger.LogWarning("Sale with ID {SaleId} not found.", command.Id);
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");
        }

        logger.LogInformation("Updating Sale with ID {SaleId}", command.Id);

        mapper.Map(command, existingSale);
        existingSale.ApplyBusinessRules();

        await saleRepository.UpdateAsync(existingSale, cancellationToken);

        logger.LogInformation("Sale with ID {SaleId} updated successfully.", command.Id);

        return mapper.Map<UpdateSaleResult>(existingSale);
    }
}