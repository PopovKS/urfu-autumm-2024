using Microsoft.EntityFrameworkCore;
using UrfuAutumn.Core.Domain;
using UrfuAutumn.Core.Domain.Repositories;

namespace UrfuAutumn.Infrastructure.DataStorage.Repositories;

public class OrderRepository : EFRepository<Order, ServerDbContext>, IOrderRepository
{
    private readonly ServerDbContext _context;
    public OrderRepository(ServerDbContext context) : base(context)
    {
        _context = context;
    }
}