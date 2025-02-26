using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
///     Handler for processing CreateSaleCommand requests.
/// </summary>
public class CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    /// <summary>
    ///     Handles the CreateSaleCommand request.
    /// </summary>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = mapper.Map<Sale>(command);
        sale.ApplyBusinessRules();

        var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);
        return mapper.Map<CreateSaleResult>(createdSale);
    }
}