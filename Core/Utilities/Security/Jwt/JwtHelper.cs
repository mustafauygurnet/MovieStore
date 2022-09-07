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
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
    }

    public AccessToken CreateJwtToken(User user, IEnumerable<OperationClaimOfUserDto> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = _CreateJwtSecurityToken(signingCredentials, user, operationClaims);
        var handler = new JwtSecurityTokenHandler();
        var token = handler.WriteToken(jwt);

        var accessToken = new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };

        return accessToken;
    }

    private JwtSecurityToken _CreateJwtSecurityToken(SigningCredentials signingCredentials, User user,
        IEnumerable<OperationClaimOfUserDto> operationClaims)
    {
        var jwtSecurityToken = new JwtSecurityToken
        (
            _tokenOptions.Issuer,
            _tokenOptions.Audience,
            _SetClaims(user, operationClaims),
            DateTime.Now,
            _accessTokenExpiration,
            signingCredentials
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