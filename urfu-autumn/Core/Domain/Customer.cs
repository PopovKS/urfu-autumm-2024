using UrfuAutumn.Core.Domain.Events;
using UrfuAutumn.Core.Domain.SharedKernel;

namespace UrfuAutumn.Core.Domain;

public class Customer : Entity<long>, IAggregateRoot
{
    public Customer()
    {
       // AddDomainEvent(new CreateCustomerDomainEvent(this));
    }
    public string Name
    {
        get; set;
    }

    public string Email { get; set; }
    
    public Address Address { get; set; }
}