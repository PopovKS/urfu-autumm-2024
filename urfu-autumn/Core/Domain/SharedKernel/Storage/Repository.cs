namespace UrfuAutumn.Core.Domain.SharedKernel.Storage;

public abstract class Repository<TAggregateRoot>(IUnitOfWork unitOfWork): 
    ReadOnlyRepository<TAggregateRoot>, IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    public abstract ValueTask<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    public abstract Task AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    public abstract Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    public abstract Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);

    public IUnitOfWork UnitOfWork
    {
        get
        {
            if (ReadOnly)
            {
                throw new NotSupportedException("For current repository enable readonly mode"); 
            }
            
            return unitOfWork;
        }
    }
}