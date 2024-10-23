namespace UrfuAutumn.Application.Result;

public class Result : IResult
{
    public bool IsSuccessfull => _errors.Count < 1;
    private readonly List<IError> _errors = [];

    protected void AddError(IError error)
    {
        ArgumentNullException.ThrowIfNull(error);
        _errors.Add(error);
    }
    
    public IReadOnlyList<IError> GetErrors() => _errors;
    
    private static readonly Result _success = new();
    public static Result Success() => _success;

    public static Result Error(IError error)
    {
        var result = new Result();
        result.AddError(error);
        return result;
    }
}