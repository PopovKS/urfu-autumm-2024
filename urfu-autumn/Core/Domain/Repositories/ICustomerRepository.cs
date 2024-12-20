using UrfuAutumn.Core.Domain.SharedKernel.Storage;

namespace UrfuAutumn.Core.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IReadOnlyList<Customer>> SearchCustomerByNameAndEmail(string name, string email, CancellationToken cancellationToken);
}