// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.

using OrdersApi.Domain.Entities;
using OrdersApi.Domain.ValueObjects;

namespace OrdersApi.Infrastructure.Data.SeedData;

/// <summary>
//  SeedData class to seed initial data into the database.
/// </summary>
public static class SeedData
{
    /// <summary>
    // Recreate database if it already exists.
    // Use the OrdersContext to add initial data for Users and Orders and products.
    // Generate 10 Users with 2 Orders each, and each Order with Status Completed and 3 Products.
    /// </summary>
    public static void Initialize(OrdersContext context)
    {
        if (context.Database.EnsureCreated())
        {
            // Create 10 users
            for (int i = 1; i <= 10; i++)
            {
                var userId = Guid.NewGuid();
                var user = new User(
                    id: userId,
                    name: $"User {i}",
                    email: GenerateEmail(userId)
                );
                context.Users.Add(user);
                // Create 2 orders for each user
                for (int j = 1; j <= 2; j++)
                {
                    var order = new Order(
                        id: Guid.NewGuid(),
                        userId: user.Id,
                        status: OrderStatus.Completed
                    );

                    // Add 3 products to each order
                    for (int k = 1; k <= 3; k++)
                    {
                        var product = new Product(
                            id: Guid.NewGuid(),
                            name: $"Product {k}",
                            price: 10.00m * k,
                            orderId: order.Id
                        );
                        order.AddProduct(product);
                    }

                    context.Orders.Add(order);
                }
            }
            context.SaveChanges();
        }
    }

    private static string GenerateEmail(Guid userId)
    {
        return $"user_{userId.ToString().Replace("-", "")}@example.com";
    }
}