// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.

using OrdersApi.Domain.ValueObjects;

namespace OrdersApi.Domain.Entities;

/// <summary>
/// Represents an order in the Orders API domain.
/// Order is Aggregation Root and contains a User with collection of Products.
/// </summary>
public class Order
{
    private Order()
    {
        Products = [];
        Status = OrderStatus.Pending; // Use a default enum value
    } // EF Core requires a parameterless constructor

    public Order(Guid id, Guid userId, OrderStatus status, ICollection<Product>? products = null, decimal total = 0)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));
        if (!Enum.IsDefined(typeof(OrderStatus), status))
            throw new ArgumentException("Status is not a valid OrderStatus value.", nameof(status));
        
        if (products != null && products.Count == 0)
            throw new ArgumentException("Products cannot be empty.", nameof(products));
        if (total < 0)
            throw new ArgumentOutOfRangeException(nameof(total), "Total cannot be negative.");

        Id = id;
        UserId = userId;
        Status = status;
        Products = products is not null ? new List<Product>(products) : new List<Product>();
        Total = total;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public OrderStatus Status { get; private set; }
    public ICollection<Product> Products { get; private set; }
    public decimal Total { get; private set; }

    /// <summary>
    /// Adds a single product to the order and updates the total.
    /// </summary>
    /// <param name="product">The product to add.</param>
    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        Products.Add(product);
        Total += product.Price;
    }

    /// <summary>
    /// Adds multiple products to the order and updates the total.
    /// </summary>
    /// <param name="products">The products to add.</param>
    public void AddProducts(IEnumerable<Product> products)
    {
        ArgumentNullException.ThrowIfNull(products);
        foreach (var product in products)
        {
            AddProduct(product);
        }
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is null || GetType() != obj.GetType())
            return false;

        var other = (Order)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Order? left, Order? right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(Order? left, Order? right)
    {
        return !(left == right);
    }

    // Add behavior here (DDD principle)
}