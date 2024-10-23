namespace UrfuAutumn.Core.Domain.SharedKernel.Storage;

public interface IRepository<TAggregateRoot> : IReadOnlyRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    ValueTask<TAggregateRoot> AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    Task AddRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    Task RemoveAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken);
    Task RemoveRangeAsync(IReadOnlyList<TAggregateRoot> aggregateRoots, CancellationToken cancellationToken);
    IUnitOfWork UnitOfWork { get; }
}