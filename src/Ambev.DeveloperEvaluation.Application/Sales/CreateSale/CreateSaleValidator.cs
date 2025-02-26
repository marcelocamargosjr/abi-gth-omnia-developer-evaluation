using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
///     Validator for CreateSaleCommand that defines validation rules for sale creation.
/// </summary>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleValidator()
    {
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.SaleDate).NotEmpty();
        RuleFor(sale => sale.CustomerId).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 100);
        RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemValidator());
    }
}

/// <summary>
///     Validator for CreateSaleItemCommand that defines validation rules for sale items.
/// </summary>
public class CreateSaleItemValidator : AbstractValidator<CreateSaleItemCommand>
{
    public CreateSaleItemValidator()
    {
        RuleFor(item => item.ProductId).NotEmpty().Length(3, 50);
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThan(0);
    }
}