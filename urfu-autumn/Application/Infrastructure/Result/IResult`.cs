namespace UrfuAutumn.Application.Result;

public interface IResult<out T> : IResult
{
    T Value { get; }
}