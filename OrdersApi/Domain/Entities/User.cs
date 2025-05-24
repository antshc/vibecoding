// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.
namespace OrdersApi.Domain.Entities;

// <summary>
// Represents a user in the Orders API domain.
// </summary>
public class User
{
    private User()
    {
        // EF Core requires a parameterless constructor
        Name = string.Empty;
        Email = string.Empty;
        Orders = new List<Order>();
    }

    public User(Guid id, string name, string email)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or whitespace.", nameof(email));

        Id = id;
        Name = name;
        Email = email;
        Orders = new List<Order>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public ICollection<Order> Orders { get; private set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is null || GetType() != obj.GetType())
            return false;

        var other = (User)obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(User? left, User? right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(User? left, User? right)
    {
        return !(left == right);
    }
}
