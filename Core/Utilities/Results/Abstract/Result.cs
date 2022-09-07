namespace Core.Utilities.Results.Abstract;

public abstract class Result : IResult
{
    public string Message { get; }
    public bool Success { get; }

    protected Result(string message,bool success) : this(success)
    {
        Message = message;
    }
    
    protected Result(bool success)
    {
        Success = success;
    }


}