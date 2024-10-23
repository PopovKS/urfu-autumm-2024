using Microsoft.EntityFrameworkCore;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.SharedKernel.Storage;

namespace UrfuAutumn.Infrastructure.DataStorage;

public class ServerDbContext : DbContext, IUnitOfWork
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}