using System.Linq.Expressions;

namespace UrfuAutumn.Core.Domain.SharedKernel.Specification;

public interface ISpecification<TAggregateRoot> where TAggregateRoot: class, IAggregateRoot
{
    Expression<Func<TAggregateRoot, bool>> IsSatisfiedBy();
}

