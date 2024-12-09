using UrfuAutumn.Application.Infrastructure.Cqs;
using UrfuAutumn.Application.Result;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.SharedKernel.Specification;
using UrfuAutumn.Core.Domain.SharedKernel.Storage;
using UrfuAutumn.Infrastructure.DataStorage.Repositories;

namespace UrfuAutumn.Application.Features.Customers;

public class SearchCustomersQuery : Query<IReadOnlyList<Customer>>
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class SearchCustomersQueryHandler : QueryHandler<SearchCustomersQuery, IReadOnlyList<Customer>>
{
    private readonly IReadOnlyRepository<Customer> _customerRepository;

    public SearchCustomersQueryHandler(IReadOnlyRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public override async Task<Result<IReadOnlyList<Customer>>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
    {
        ISpecification<Customer> searcCustomerSpecification = null;


        var searchEmailSpecification = CustomerSpecification.SearchByName(request.Name);
        var searchNameSpecification = CustomerSpecification.SearchByName(request.Email);

        searcCustomerSpecification = searchNameSpecification.And(searchEmailSpecification);

        if (request.Name == "Abcd1")
        {
            searcCustomerSpecification =
                searcCustomerSpecification.Or(Specification<Customer>.Create(x => string.IsNullOrEmpty(x.Email)));
        }
        
        var customers = await _customerRepository.ListAsync(searcCustomerSpecification, cancellationToken);
        
        
        var customerIds = await _customerRepository.QueryAsync(x => x.Where(searcCustomerSpecification).OrderByDescending(y => y.Email).Select(y => y.Id), cancellationToken);
        
        
        return Success(customers);
    }
}