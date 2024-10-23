namespace UrfuAutumn.Application.Result;

public class Result<TValue> : Result, IResult<TValue>
{
    private Result(TValue value)
    {
        Value = value;
    }

    private Result(IError error)
    {
        AddError(error);
    }

    public TValue Value { get; }

    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }

    public new static Result<TValue> Error(IError error)
    {
        return new Result<TValue>(error);
    }
}