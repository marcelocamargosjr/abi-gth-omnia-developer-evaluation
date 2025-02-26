using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
///     Validator for the <see cref="Sale" /> entity.
///     Ensures that data consistency rules are applied.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty()
            .WithMessage("Sale number cannot be empty.");

        RuleFor(sale => sale.SaleDate)
            .NotEmpty()
            .WithMessage("Sale date is required.");

        RuleFor(sale => sale.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

        RuleFor(sale => sale.Branch)
            .NotEmpty()
            .WithMessage("Branch is required.");

        RuleForEach(sale => sale.Items)
            .SetValidator(new SaleItemValidator());
    }
}