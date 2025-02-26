using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
///     Handler for processing UpdateSaleCommand requests.
/// </summary>
public class UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    /// <summary>
    ///     Handles the UpdateSaleCommand request.
    /// </summary>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale == null)
            throw new KeyNotFoundException($"Sale with ID {command.Id} not found");

        mapper.Map(command, existingSale);

        await saleRepository.UpdateAsync(existingSale, cancellationToken);
        return mapper.Map<UpdateSaleResult>(existingSale);
    }
}