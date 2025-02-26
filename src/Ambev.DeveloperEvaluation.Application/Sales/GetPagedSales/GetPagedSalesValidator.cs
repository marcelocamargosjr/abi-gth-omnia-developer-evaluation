using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetPagedSales;

/// <summary>
///     Validator for GetPagedSalesQuery.
/// </summary>
public class GetPagedSalesValidator : AbstractValidator<GetPagedSalesQuery>
{
    /// <summary>
    ///     Initializes validation rules for GetPagedSalesQuery.
    /// </summary>
    public GetPagedSalesValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage("Size must be greater than 0.");
    }
}