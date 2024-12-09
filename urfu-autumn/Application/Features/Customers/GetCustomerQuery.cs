using Microsoft.AspNetCore.Mvc;
using UrfuAutumn.Application.Infrastructure.Cqs;
using UrfuAutumn.Application.Result;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Repositories;
using UrfuAutumn.Core.Domain.SharedKernel.Storage;

namespace UrfuAutumn.Application.Features.Customers;

public class GetCustomerQuery : Query<Customer>
{
    [FromQuery(Name = "SmartId")]
    public long Id { get; set; }
}

public class GetCustomerQueryHandler : QueryHandler<GetCustomerQuery, Customer>
{
    private readonly IReadOnlyRepository<Customer> _customerRepository;
    private readonly ICustomerRepository _writeRepository;

    public GetCustomerQueryHandler(IReadOnlyRepository<Customer> customerRepository, ICustomerRepository writeRepository)
    {
        _customerRepository = customerRepository;
        _writeRepository = writeRepository;
    }
    public override async Task<Result<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (customer == null)
        {
            return Error(new CustomerNotFoundError(request.Id));
        }

        customer.Name = "Customer 123467";
        
        
        var customer2 = await _writeRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        customer2.Name = "Customer 12345609876";
        await _writeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Success(customer);
    }
    
    
    public class CustomerNotFoundError : Error
    {
        public CustomerNotFoundError(long id)
        {
            Data[nameof(id)] = id;
        }
    
        public override string Type => nameof(ValidationError);
    }
}