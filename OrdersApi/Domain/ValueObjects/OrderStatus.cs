// Follow StyleCop standards (docs, access modifiers, namespace, etc.) defined in .editorconfig.
// Follow Code standards from the file code-standards.adoc for code generation.

// Create OrderStatus enum to represent the status of an order.
// Status can be Pending, payed, cancelled, or completed.

namespace OrdersApi.Domain.ValueObjects;

/// <summary>
/// Represents the status of an order.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// The order is pending.
    /// </summary>
    Pending,

    /// <summary>
    /// The order has been paid.
    /// </summary>
    Paid,

    /// <summary>
    /// The order has been cancelled.
    /// </summary>
    Cancelled,

    /// <summary>
    /// The order has been completed.
    /// </summary>
    Completed
}