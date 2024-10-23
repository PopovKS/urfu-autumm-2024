using MediatR;
using IResult = UrfuAutumn.Application.Result.IResult;

namespace UrfuAutumn.Application.Infrastructure.Cqs;

public abstract class HandleBase<T, TResult> : IRequestHandler<T, TResult> where T : IRequest<TResult>
    where TResult : class, IResult
{
    async Task<TResult> IRequestHandler<T, TResult>.Handle(T request, CancellationToken token)
    {
        var result = await CoreHandle(request, token);
        return (TResult) result;
    }
    
    public abstract Task<TResult> Handle(T request, CancellationToken cancellationToken);

    protected virtual async Task<IResult> CoreHandle(T request, CancellationToken cancellationToken)
    {
        var canHandle = await CanHandle(request, cancellationToken);
        if (!canHandle.IsSuccessfull)
        {
            return canHandle;
        }
        
        return await Handle(request, cancellationToken);
    }

    protected virtual Task<Result.Result> CanHandle(T request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Result.Result.Success());
    }
}