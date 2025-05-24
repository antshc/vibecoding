// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApi.Domain.Entities;

// Create Entity Configuration for Product with Key id(Guid), Name(string), Price(decimal).
// Order has many Products.
namespace OrdersApi.Infrastructure.Data.Configurations;

/// <summary>
/// Configures the Product entity for the Orders API.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Configure the primary key
        builder.HasKey(p => p.Id);

        // Configure properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Configure foreign key relationship with Order
        builder.HasOne<Order>()
            .WithMany(o => o.Products)
            .HasForeignKey(p => p.OrderId);

        // Configure table name
        builder.ToTable("Products");
    }
}