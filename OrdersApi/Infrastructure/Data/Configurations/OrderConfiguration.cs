// Use Folder Structure and Code standarts from Readme.adoc for code generation.
// Create Order entity configuration class with Fluent API.
using OrdersApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrdersApi.Infrastructure.Data.Configurations;

/// <summary>
/// Configures the Order entity for the Orders API.
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Configure the primary key
        builder.HasKey(o => o.Id);

        // Configure properties
        builder.Property(o => o.UserId)
            .IsRequired();

        // Save enum Status as string
        builder.Property(o => o.Status)
            .IsRequired()
            .HasMaxLength(50)
            .HasConversion<string>();

        builder.Property(o => o.Total)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Configure relationships
        builder.HasMany(o => o.Products)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId)
            .IsRequired();

        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .IsRequired();

        // Configure table name
        builder.ToTable("Orders");
    }
}