using System.Linq.Expressions;

namespace UrfuAutumn.Core.Domain.SharedKernel.Storage;

public interface IReadOnlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    bool ReadOnly { get; set; }
    ValueTask<TAggregateRoot?> FindAsync(object[] keyValues, CancellationToken cancellationToken);
    Task<IReadOnlyList<TAggregateRoot>> ListAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<TAggregateRoot>> ListAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot> SingleAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot> SingleAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot?> SingleOrDefaultAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot?> SingleOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<TAggregateRoot> FirstAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot> FirstAsync(Expression<Func<TAggregateRoot, bool>> predicate,CancellationToken cancellationToken);
    
    Task<TAggregateRoot?> FirstOrDefaultAsync(CancellationToken cancellationToken);
    Task<TAggregateRoot?> FirstOrDefaultAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);
    
    Task<long> LongCountAsync(CancellationToken cancellationToken);
    Task<long> LongCountAsync(Expression<Func<TAggregateRoot, bool>> predicate, CancellationToken cancellationToken);

    Task<IReadOnlyList<TResult>> QueryAsync<TResult>(Func<IQueryable<TAggregateRoot>, IQueryable<TResult>> predicate,
        CancellationToken cancellationToken);
}