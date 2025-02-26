using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
///     Represents a sale transaction in the system.
///     This entity follows domain-driven design principles and includes business rule validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    ///     Unique identifier for the sale transaction.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    ///     Date when the sale was made.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    ///     Customer ID associated with the sale.
    /// </summary>
    public string CustomerId { get; set; } = string.Empty;

    /// <summary>
    ///     Total sale amount after applying discounts.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    ///     Branch where the sale was made.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    ///     List of sale items associated with the transaction.
    /// </summary>
    public List<SaleItem> Items { get; private set; } = [];

    /// <summary>
    ///     Indicates whether the sale has been canceled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Sale" /> class.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.UtcNow;
    }

    /// <summary>
    ///     Adds an item to the sale and applies business rules.
    /// </summary>
    public void AddItem(string productId, int quantity, decimal unitPrice)
    {
        if (quantity > 20)
            throw new ArgumentException("Cannot sell more than 20 identical items.");

        var discount = CalculateDiscount(quantity);
        var totalItemAmount = quantity * unitPrice;

        Items.Add(new SaleItem
        {
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Discount = discount,
            TotalAmount = totalItemAmount // Total amount BEFORE discount
        });

        CalculateTotalAmount();
    }

    /// <summary>
    ///     Applies business rules to all sale items.
    /// </summary>
    public void ApplyBusinessRules()
    {
        foreach (var saleItem in Items)
        {
            if (saleItem.Quantity > 20)
                throw new ValidationException("Cannot sell more than 20 identical items.");

            saleItem.Discount = CalculateDiscount(saleItem.Quantity);
            saleItem.TotalAmount = saleItem.Quantity * saleItem.UnitPrice;
        }

        CalculateTotalAmount();
    }

    /// <summary>
    ///     Calculates the discount based on the quantity.
    /// </summary>
    private static decimal CalculateDiscount(int quantity)
    {
        return quantity switch
        {
            >= 10 and <= 20 => 0.20m,
            >= 4 => 0.10m,
            _ => 0m
        };
    }

    /// <summary>
    ///     Recalculates the total sale amount with applied discounts.
    /// </summary>
    private void CalculateTotalAmount()
    {
        TotalAmount = Items.Sum(item => item.TotalAmount * (1 - item.Discount)); // Total amount AFTER discount
    }

    /// <summary>
    ///     Cancels the sale transaction.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    ///     Validates the sale entity using <see cref="SaleValidator" />.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}