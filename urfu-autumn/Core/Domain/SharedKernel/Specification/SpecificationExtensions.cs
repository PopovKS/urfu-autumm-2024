using Mono.Linq.Expressions;

namespace UrfuAutumn.Core.Domain.SharedKernel.Specification;

public static class SpecificationExtensions
{
    public static ISpecification<TAggregateRoot> And<TAggregateRoot>(this ISpecification<TAggregateRoot> specLeft,
        ISpecification<TAggregateRoot> specRight)
        where TAggregateRoot : class, IAggregateRoot
    {
        if (specLeft == null)
        {
            return specRight;
        }

        var specLeftExpression = specLeft.IsSatisfiedBy();
        var specRightExpression = specRight.IsSatisfiedBy();
        
        var andAlsoExpression = specLeftExpression.AndAlso(specRightExpression);

        return new Specification<TAggregateRoot>(andAlsoExpression);
    }
    
    
    public static ISpecification<TAggregateRoot> Or<TAggregateRoot>(this ISpecification<TAggregateRoot> specLeft,
        ISpecification<TAggregateRoot> specRight)
        where TAggregateRoot : class, IAggregateRoot
    {
        if (specLeft == null)
        {
            return specRight;
        }

        var specLeftExpression = specLeft.IsSatisfiedBy();
        var specRightExpression = specRight.IsSatisfiedBy();
        
        var orAlsoExpression = specLeftExpression.OrElse(specRightExpression);

        return new Specification<TAggregateRoot>(orAlsoExpression);
    }
    
    public static ISpecification<TAggregateRoot> Or<TAggregateRoot>(this ISpecification<TAggregateRoot> specLeft)
        where TAggregateRoot : class, IAggregateRoot
    {
        var notExpression = specLeft.IsSatisfiedBy().Not();
        return new Specification<TAggregateRoot>(notExpression);
    }
}