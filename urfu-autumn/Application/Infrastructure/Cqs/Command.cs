using MediatR;

namespace UrfuAutumn.Application.Infrastructure.Cqs;

public abstract class Command : IRequest<Result.Result>, ICommand
{
    
}