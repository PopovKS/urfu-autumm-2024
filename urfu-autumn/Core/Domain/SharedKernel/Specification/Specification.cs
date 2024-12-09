using System.Linq.Expressions;

namespace UrfuAutumn.Core.Domain.SharedKernel.Specification;

public class Specification<TAggregateRoot> : ISpecification<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
{
    private readonly Expression<Func<TAggregateRoot, bool>> _expression;

    public Specification(Expression<Func<TAggregateRoot, bool>> expression)
    {
        _expression = expression;
    }
    
    public Expression<Func<TAggregateRoot, bool>> IsSatisfiedBy()
    {
        return _expression;
    }
    
    public static ISpecification<TAggregateRoot> Empty() => new Specification<TAggregateRoot>(x => true);

    public static ISpecification<TAggregateRoot> Create(Expression<Func<TAggregateRoot, bool>> expression)
    {
        return new Specification<TAggregateRoot>(expression);
    }
}