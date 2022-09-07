using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace Core.Utilities.Security.Jwt;

public interface IToken
{
    AccessToken CreateJwtToken(User user, IEnumerable<OperationClaimOfUserDto> operationClaims);
}