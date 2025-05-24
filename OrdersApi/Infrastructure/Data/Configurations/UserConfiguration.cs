// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.
// Create Entity Configuration for User with Key id(Guid), Name(string), Email(string).

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrdersApi.Domain.Entities;

namespace OrdersApi.Infrastructure.Data.Configurations;

/// <summary>
/// Configures the User entity for the Orders API.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Configure the primary key
        builder.HasKey(u => u.Id);

        // Configure properties
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);

        // Configure the relationship: User has many Orders
        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure table name
        builder.ToTable("Users");
    }
}