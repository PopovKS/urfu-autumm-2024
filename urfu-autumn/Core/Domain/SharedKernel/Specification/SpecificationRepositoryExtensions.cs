using UrfuAutumn.Core.Domain.SharedKernel.Storage;

namespace UrfuAutumn.Core.Domain.SharedKernel.Specification;

public static class SpecificationRepositoryExtensions
{
     public static Task<IReadOnlyList<TEntity>> ListAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository
        , ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.ListAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<TEntity> SingleAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken)
        where TEntity : Entity, IAggregateRoot
    {
        return readOnlyRepository.SingleAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<TEntity?> SingleOrDefaultAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.SingleOrDefaultAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<TEntity> FirstAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.FirstAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<TEntity?> FirstOrDefaultAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.FirstOrDefaultAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<int> CountAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.CountAsync(specification.IsSatisfiedBy(), cancellationToken);
    }

    public static Task<long> LongCountAsync<TEntity>(this IReadOnlyRepository<TEntity> readOnlyRepository,
        ISpecification<TEntity> specification, CancellationToken cancellationToken) where TEntity: Entity, IAggregateRoot
    {
        return readOnlyRepository.LongCountAsync(specification.IsSatisfiedBy(), cancellationToken);
    }
}