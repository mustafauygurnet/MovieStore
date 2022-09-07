using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects;

public class SecuredOperation : MethodInterception
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string[] _roles;

    public SecuredOperation(string roles)
    {
        _roles = roles.Split(",");
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        var claims = _httpContextAccessor.HttpContext.User.ClaimsRole();

        foreach (var claim in claims)
            if (_roles.Contains(claim))
                return;

        throw new Exception("Yetkiniz Yok");
    }
}