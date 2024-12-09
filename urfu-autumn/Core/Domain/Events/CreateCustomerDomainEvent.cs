using UrfuAutumn.Core.Domain.SharedKernel;

namespace UrfuAutumn.Core.Domain.Events;

public class CreateCustomerDomainEvent : IDomainEvent
{
    public long CustomerId { get; set; }
    
    public CreateCustomerDomainEvent(Customer customer)
    {
        CustomerId = customer.Id;
    }
}

public class UpdateCustomerDomainEvent : IDomainEvent
{
    public long CustomerId { get; set; }
    
    public UpdateCustomerDomainEvent(Customer customer)
    {
        CustomerId = customer.Id;
    }
}