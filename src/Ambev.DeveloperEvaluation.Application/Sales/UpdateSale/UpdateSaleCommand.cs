using System;
using System.Collections.Generic;
using System.Linq;
using Ambev.DeveloperEvaluation.Common.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
///     Command for updating an existing sale.
/// </summary>
/// <remarks>
///     This command is used to capture the required data for updating a sale,
///     including sale number, sale date, customer ID, branch, and items.
///     It implements <see cref="IRequest{TResponse}" /> to initiate the request
///     that returns a <see cref="UpdateSaleResult" />.
///     The data provided in this command is validated using the
///     <see cref="UpdateSaleValidator" /> which extends
///     <see cref="AbstractValidator{T}" /> to ensure that the fields are correctly
///     populated and follow the required rules.
/// </remarks>
public class UpdateSaleCommand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public List<UpdateSaleItemCommand> Items { get; set; } = [];

    public bool IsCancelled { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

/// <summary>
///     Represents an item in the sale.
/// </summary>
public class UpdateSaleItemCommand
{
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}