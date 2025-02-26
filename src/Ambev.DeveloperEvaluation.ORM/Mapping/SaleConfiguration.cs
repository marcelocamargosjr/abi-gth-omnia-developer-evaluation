using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

/// <summary>
///     Configuration for the <see cref="Sale" /> entity.
///     Defines database mappings for the Sales table.
/// </summary>
public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.SaleDate)
            .IsRequired();

        builder.Property(s => s.CustomerId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(s => s.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Branch)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(s => s.Items)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.IsCancelled)
            .IsRequired();
    }
}