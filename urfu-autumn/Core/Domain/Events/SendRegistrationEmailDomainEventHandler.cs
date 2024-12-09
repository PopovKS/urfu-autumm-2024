using MediatR;
using UrfuAutumn.Core.Domain.Repositories;

namespace UrfuAutumn.Core.Domain.Events;

public class CreateEmptyCustomerOrderDomainEventHandler: INotificationHandler<CreateCustomerDomainEvent>
{
    private readonly IOrderRepository _orderRepository;

    public CreateEmptyCustomerOrderDomainEventHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateCustomerDomainEvent notification, CancellationToken cancellationToken)
    {
        var newOrder = new Order();
        await _orderRepository.AddAsync(newOrder, cancellationToken);
    }
}

// public class SendRegistrationEmailDomainEventHandler : INotificationHandler<CreateCustomerDomainEvent>, INotificationHandler<UpdateCustomerDomainEvent>
// {
//     public SendRegistrationEmailDomainEventHandler(IBus bus)
//     {
//         
//     }
//     
//     public Task Handle(CreateCustomerDomainEvent notification, CancellationToken cancellationToken)
//     {
//         SendIntegrationMessage();
//     }
//
//     public Task Handle(UpdateCustomerDomainEvent notification, CancellationToken cancellationToken)
//     {
//         SendIntegrationMessage();
//     }
//
//     private void SendIntegrationMessage()
//     {
//         //_bus.PublushMessages(CreateCustomerIntegrationMessage);
//     }
// }