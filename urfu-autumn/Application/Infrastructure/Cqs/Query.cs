using MediatR;

namespace UrfuAutumn.Application.Infrastructure.Cqs;

public abstract class Query<TResult> : IQuery<Result.Result<TResult>>, IRequest<Result.Result<TResult>>
{
    
}