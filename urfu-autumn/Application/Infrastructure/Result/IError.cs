namespace UrfuAutumn.Application.Result;

public interface IError
{
    string Type { get; }
    Dictionary<string, object> Data { get; }
}