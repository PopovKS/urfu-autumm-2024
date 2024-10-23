using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Repositories;

namespace UrfuAutumn.Infrastructure.DataStorage.Repositories;

public sealed class CustomerRepository(ServerDbContext context)
    : EFRepository<Customer, ServerDbContext>(context), ICustomerRepository;