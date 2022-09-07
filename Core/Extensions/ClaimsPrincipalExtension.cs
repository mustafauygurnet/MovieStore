using System.Security.Claims;

namespace Core.Extensions;

public static class ClaimsPrincipalExtension
{
    private static IEnumerable<string>? FindClaims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        return claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
    }

    public static IEnumerable<string>? ClaimsRole(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal?.FindClaims(ClaimTypes.Role).ToList();
    }
}