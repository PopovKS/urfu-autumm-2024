using Microsoft.EntityFrameworkCore;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Repositories;
using UrfuAutumn.Core.Domain.SharedKernel.Specification;

namespace UrfuAutumn.Infrastructure.DataStorage.Repositories;

public sealed class CustomerRepository(ServerDbContext context)
    : EFRepository<Customer, ServerDbContext>(context), ICustomerRepository
{
    public async Task<IReadOnlyList<Customer>> SearchCustomerByNameAndEmail(string name, string email, CancellationToken cancellationToken)
    {
        return await this.ListAsync(CustomerSpecification.SearchByNameAndEmail(name, email), cancellationToken);
    }
}


public static class CustomerSpecification
{
    public static ISpecification<Customer> SearchByEmail(string email) => Specification<Customer>.Create(x => x.Email == email);
    public static ISpecification<Customer> SearchByName(string name) => Specification<Customer>.Create(x => x.Name == name);
    internal static ISpecification<Customer> SearchByNameAndEmail(string email, string name) => SearchByEmail(email)
        .And(Specification<Customer>.Create(x => EF.Functions.Like(nameof(x.Name), $"%{name}%")));
}