using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

/// <summary>
///     Provides methods for generating test data for CreateSaleHandler.
/// </summary>
public static class CreateSaleHandlerTestData
{
    private static readonly Faker<CreateSaleCommand> CreateSaleFaker = new Faker<CreateSaleCommand>()
        .RuleFor(s => s.SaleNumber, f => f.Random.AlphaNumeric(10))
        .RuleFor(s => s.SaleDate, f => f.Date.Past())
        .RuleFor(s => s.CustomerId, f => Guid.NewGuid().ToString())
        .RuleFor(s => s.Branch, f => f.Company.CompanyName());

    public static CreateSaleCommand GenerateValidCommand()
    {
        return CreateSaleFaker.Generate();
    }
}