using UrfuAutumn.Core.Domain.SharedKernel;

namespace UrfuAutumn.Core.Domain;

public class Order : Entity<long>, IAggregateRoot
{
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public Address Address { get; set; }
    
    public long CustomerId { get; set; }
}

public class OrderItem : Entity<long>
{
    public string Name { get; set; }
}