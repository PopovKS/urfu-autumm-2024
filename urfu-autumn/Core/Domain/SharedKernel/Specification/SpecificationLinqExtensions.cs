namespace UrfuAutumn.Core.Domain.SharedKernel.Specification;

public static class SpecificationLinqExtensions
{
    public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query,
        ISpecification<TEntity> specification) where TEntity : Entity, IAggregateRoot
    {
        query = query.Where(specification.IsSatisfiedBy());
        return query;
    }

    public static IEnumerable<TEntity> Where<TEntity>(this IEnumerable<TEntity> query,
        ISpecification<TEntity> specification) where TEntity : Entity, IAggregateRoot
    {
        var compileFunc = specification.IsSatisfiedBy().Compile();
        query = query.Where(compileFunc);
        return query;
    }
}