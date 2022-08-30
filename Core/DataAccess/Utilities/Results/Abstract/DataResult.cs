namespace Core.DataAccess.Utilities.Results.Abstract;

public class DataResult<T> : Result, IDataResult<T>
{
    public string Message { get; }
    public bool Success { get; }
    public T Data { get; }

    public DataResult(T data, string message, bool success) : base(message, success)
    {
        Data = data;
    }

    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }
}