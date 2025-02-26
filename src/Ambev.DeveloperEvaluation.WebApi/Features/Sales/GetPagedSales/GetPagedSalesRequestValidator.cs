using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetPagedSales;

/// <summary>
///     Validator for GetPagedSalesRequest.
/// </summary>
public class GetPagedSalesRequestValidator : AbstractValidator<GetPagedSalesRequest>
{
    public GetPagedSalesRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("Size must be greater than 0.");
    }
}