using Core.DataAccess.Utilities.Results.Abstract;

namespace Core.DataAccess.Utilities.Results.Concrete;

public class SuccessResult : Result
{
    public SuccessResult(string message) : base(message, true)
    {
    }

    public SuccessResult() : base(true)
    {
    }
}