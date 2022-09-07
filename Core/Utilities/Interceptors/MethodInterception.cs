using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public class MethodInterception : MethodInterceptionBaseAttribute, IInterceptor
{
    public override void Intercept(IInvocation invocation)
    {
        var isSuccess = true;
        OnBefore(invocation);
        try
        {
            invocation.Proceed();
        }
        catch (Exception e)
        {
            isSuccess = false;
            OnException(invocation, e);
        }
        finally
        {
            if (isSuccess) OnSuccess(invocation);
        }

        OnAfter(invocation);
    }

    protected virtual void OnBefore(IInvocation invocation)
    {
    }

    protected virtual void OnSuccess(IInvocation invocation)
    {
    }

    protected virtual void OnException(IInvocation invocation, Exception e)
    {
    }

    protected virtual void OnAfter(IInvocation invocation)
    {
    }
}