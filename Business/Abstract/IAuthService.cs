using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Jwt;

namespace Business.Abstract;

public interface IAuthService
{
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
    IDataResult<User>  IsUserExists(string email);
    IResult IsUserNotExists (string email);
    IDataResult<AccessToken> CreateToken(User user);
}