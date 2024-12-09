using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UrfuAutumn.Core.Domain.SharedKernel;
using UrfuAutumn.Core.Domain.SharedKernel.Storage;

namespace UrfuAutumn.Infrastructure.DataStorage;

public abstract class EFRepository<TAggregateRoot, TDbContext> : Repository<TAggregateRoot> 
    where TAggregateRoot : class, IAggregateRoot
    where TDbContext : DbContext, IUnitOfWork
{
    private readonly DbContext _context;
    private DbSet<TAggregateRoot> _items => _context.Set<TAggregateRoot>();
    protected virtual IQueryable<TAggregateRoot> Items => ReadOnly ? _items.AsNoTracking() : _items;
    
    public EFRepository(TDbContext context) : base(context)
    {
        _context = context;
    }

    public override async ValueTask<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
    {
        var entry =  await _context.AddAsync(aggregateRoot, cancellationToken);
        return entry.Entity;
    }

    public override Task AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken)
    {
        return _items.AddRangeAsync(aggregateRoots, cancellationToken);
    }

    public override Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken)
    { 
        _items.Remove(aggregateRoot);
        return Task.CompletedTask;
    }

    public override Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken)
    {
        _items.RemoveRange(aggregateRoots);
        return Task.CompletedTask;
    }

    public override bool ReadOnly { get; set; }
    public override ValueTask<TAggregateRoot?> FindAsync(object[] keyValues, CancellationToken cancellationToken)
    {
       return _items.FindAsync(keyValues, cancellationToken);
    }

    public override async Task<IReadOnlyList<TAggregateRoot>> ListAsync(CancellationToken cancellationToken)
    {
        return await Items.ToListAsync(cancellationToken);
    }

    public override async Task<IReadOnlyList<TAggregateRoot>> ListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return await Items.Where(predicate).ToListAsync(cancellationToken);
    }

    public override Task<TAggregateRoot> SingleAsync(CancellationToken cancellationToken)
    {
        return Items.SingleAsync(cancellationToken);
    }

    public override Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
       return Items.SingleAsync(predicate, cancellationToken);
    }

    public override Task<TAggregateRoot?> SingleOrDefaultAsync(CancellationToken cancellationToken)
    {
        return Items.SingleOrDefaultAsync(cancellationToken);
    }

    public override Task<TAggregateRoot?> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public override Task<TAggregateRoot> FirstAsync(CancellationToken cancellationToken)
    {
        return Items.FirstAsync(cancellationToken);
    }

    public override Task<TAggregateRoot> FirstAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.FirstAsync(predicate, cancellationToken);
    }

    public override Task<TAggregateRoot?> FirstOrDefaultAsync(CancellationToken cancellationToken)
    {
        return Items.FirstOrDefaultAsync(cancellationToken);
    }

    public override Task<TAggregateRoot?> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public override Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return Items.CountAsync(cancellationToken);
    }

    public override Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.CountAsync(predicate, cancellationToken);
    }

    public override Task<long> LongCountAsync(CancellationToken cancellationToken)
    {
       return Items.LongCountAsync(cancellationToken);
    }

    public override Task<long> LongCountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken)
    {
        return Items.LongCountAsync(predicate, cancellationToken);
    }

    public override async Task<IReadOnlyList<TResult>> QueryAsync<TResult>(Func<IQueryable<TAggregateRoot>, IQueryable<TResult>> predicate, CancellationToken cancellationToken)
    {
        return await predicate(Items).ToListAsync(cancellationToken);
    }
}