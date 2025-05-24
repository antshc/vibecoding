// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.
// Create OrdersContext class with DbSet<Order> and DbSet<User> properties.

using Microsoft.EntityFrameworkCore;
using OrdersApi.Domain.Entities;

namespace OrdersApi.Infrastructure.Data;

/// <summary>
/// Represents the database context for the Orders API.
/// </summary>
public class OrdersContext : DbContext
{
    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options) { }

    /// <summary>
    /// Gets or sets the collection of orders.
    /// </summary>
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// Gets or sets the collection of users.
    /// </summary>
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
       
    }
}