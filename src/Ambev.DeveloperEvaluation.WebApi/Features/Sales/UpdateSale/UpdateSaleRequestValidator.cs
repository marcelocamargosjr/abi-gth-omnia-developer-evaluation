using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
///     Validator for UpdateSaleRequest.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty().WithMessage("Sale ID is required.");
        RuleFor(sale => sale.SaleNumber).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.SaleDate).NotEmpty();
        RuleFor(sale => sale.CustomerId).NotEmpty().Length(3, 50);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 100);
        RuleForEach(sale => sale.Items).SetValidator(new UpdateSaleItemRequestValidator());
    }
}

/// <summary>
///     Validator for UpdateSaleItemRequest.
/// </summary>
public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
{
    public UpdateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductId).NotEmpty().Length(3, 50);
        RuleFor(item => item.Quantity).GreaterThan(0);
        RuleFor(item => item.UnitPrice).GreaterThan(0);
    }
}