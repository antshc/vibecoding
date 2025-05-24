// Use Folder Structure and Code standarts from Readme.adoc for code generation.
// Create Order entity configuration class with Fluent API.
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApi.Domain.Entities;
namespace OrdersApi.Infrastructure.Data.Configurations
{
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

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(o => o.Products)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(o => o.Total)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Configure table name
            builder.ToTable("Orders");
        }
    }
}