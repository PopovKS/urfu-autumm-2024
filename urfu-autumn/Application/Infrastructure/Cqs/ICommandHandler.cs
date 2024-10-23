namespace UrfuAutumn.Application.Infrastructure.Cqs;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result.Result> Handle(TCommand command,CancellationToken cancellationToken);
}