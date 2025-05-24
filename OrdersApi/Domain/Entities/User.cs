// Use Folder Structure and Code standarts from Readme.adoc for code generation.
// Create User Entity with Id(guid), Name(string).
namespace OrdersApi.Domain.Entities;

// <summary>
// Represents a user in the Orders API domain.
// </summary>
public class User
{
    private User() { } // EF Core requires a parameterless constructor

    public User(Guid id, string name)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));

        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public override bool Equals(object obj)
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

    public static bool operator ==(User left, User right)
    {
        if (ReferenceEquals(left, right))
            return true;
        if (left is null || right is null)
            return false;
        return left.Id == right.Id;
    }

    public static bool operator !=(User left, User right)
    {
        return !(left == right);
    }
}
