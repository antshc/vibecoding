// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.

namespace OrdersApi.Domain.Entities;

/// <summary>
/// Represents a product in the Orders API domain.
/// </summary>

// Create Enity Product with Key id(Guid), Name(string), Price(decimal).
public class Product
{
    private Product()
    {
        // Initialize non-nullable properties with default values for EF Core
        Name = string.Empty;
    }

    public Product(Guid id, string name, decimal price, Guid? orderId = null)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");
        if (orderId.HasValue && orderId.Value == Guid.Empty)
            throw new ArgumentException("OrderId cannot be empty.", nameof(orderId));

        Id = id;
        Name = name;
        Price = price;
        OrderId = orderId;
    }

    public Guid Id { get; private set; }
    public Guid? OrderId { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    // Navigation property for the related Order
    public Order? Order { get; private set; }

    /// <summary>
    /// Sets the OrderId for the product.
    /// </summary>
    /// <param name="orderId">The order identifier.</param>
    public void SetOrderId(Guid orderId)
    {
        if (orderId == Guid.Empty)
            throw new ArgumentException("OrderId cannot be empty.", nameof(orderId));

        OrderId = orderId;
    }
}

