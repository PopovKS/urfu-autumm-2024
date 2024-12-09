using UrfuAutumn.Application.Infrastructure.Cqs;
using UrfuAutumn.Application.Result;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Events;
using UrfuAutumn.Core.Domain.Repositories;

namespace UrfuAutumn.Application.Features.Customers;

public sealed class CreateCustomerCommand : Command
{
    public string Name { get; set; }
}

public class ValidationError : Error
{
    public override string Type => nameof(ValidationError);
}

public sealed class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public override async Task<Result.Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return Error(new ValidationError() { Data = {{nameof(request.Name), "Empty value" }}});
        }
        
        
        var customer = new Customer();
        customer.Name = request.Name;
        
        await _customerRepository.AddAsync(customer, cancellationToken);
        customer.AddDomainEvent(new CreateCustomerDomainEvent(customer));
        await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        
        
        return Success();
    }
}