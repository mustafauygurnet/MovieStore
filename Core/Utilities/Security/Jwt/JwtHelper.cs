using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt;

public class JwtHelper : IToken
{
    private DateTime _accessTokenExpiration;
    private readonly TokenOptions _tokenOptions;

    public JwtHelper(IConfiguration configuration)
    {
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateJwtToken(User user, IEnumerable<OperationClaimOfUserDto> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtSecurityToken jwt = _CreateJwtSecurityToken(signingCredentials, user, operationClaims);
        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwt);
        
        AccessToken accessToken = new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };

        return accessToken;
    }

    private JwtSecurityToken _CreateJwtSecurityToken(SigningCredentials signingCredentials, User user,
        IEnumerable<OperationClaimOfUserDto> operationClaims)
    {
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        (
            issuer: _tokenOptions.Issuer,
            audience: _tokenOptions.Audience,
            claims: _SetClaims(user, operationClaims),
            notBefore: DateTime.Now,
            expires: _accessTokenExpiration,
            signingCredentials: signingCredentials
        );
        return jwtSecurityToken;
    }

    private IEnumerable<Claim> _SetClaims(User user, IEnumerable<OperationClaimOfUserDto> operationClaims)
    {
        var claims = new List<Claim>();

        claims.AddNameIdentifier(user.UserId.ToString());
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddEmail(user.Email);
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

        return claims.ToList();
    }
}