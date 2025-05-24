// Use Folder Structure and Code standarts from Readme.adoc for code generation.

namespace OrdersApi.Domain.Entities;

public class Order
{
    private Order() { } // EF Core requires a parameterless constructor

    public Order(Guid id, Guid userId, string status, string products, decimal total)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId cannot be empty.", nameof(userId));
        if (string.IsNullOrWhiteSpace(status))
            throw new ArgumentException("Status cannot be null or whitespace.", nameof(status));
        if (string.IsNullOrWhiteSpace(products))
            throw new ArgumentException("Products cannot be null or whitespace.", nameof(products));
        if (total < 0)
            throw new ArgumentOutOfRangeException(nameof(total), "Total cannot be negative.");

        Id = id;
        UserId = userId;
        Status = status;
        Products = products;
        Total = total;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Status { get; private set; }
    public string Products { get; private set; }
    public decimal Total { get; private set; }

    public override bool Equals(object obj)
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

    public static bool operator ==(Order left, Order right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(Order left, Order right)
    {
        return !(left == right);
    }

    // Add behavior here (DDD principle)
}