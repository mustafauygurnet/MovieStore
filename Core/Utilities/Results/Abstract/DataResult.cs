namespace Core.Utilities.Results.Abstract;

public abstract class DataResult<T> : Result, IDataResult<T>
{
    public DataResult(T data, string message, bool success) : base(message, success)
    {
        Data = data;
    }

    public DataResult(T data, bool success) : base(success)
    {
        Data = data;
    }

    public string Message { get; }
    public bool Success { get; }
    public T Data { get; }
}