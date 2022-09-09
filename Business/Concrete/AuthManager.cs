using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
private readonly IToken _tokenHelper;

    public AuthManager(IUserService userService, IToken tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }

    [ValidationAspect(typeof(UserValidator))]
    public IDataResult<User> Login(UserForLoginDto userForLoginDto)
    {
        var userToCheck = _userService.GetByEmail(userForLoginDto.Email);

        if (!userToCheck.Success)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        var password = userForLoginDto.Password;
        var passwordHash = userToCheck.Data.PasswordHash;
        var passwordSalt = userToCheck.Data.PasswordSalt;
        
        var checkToPassword = HashingHelper.VerifyHash(password,passwordHash,passwordSalt);

        if (!checkToPassword)
        {
            return new ErrorDataResult<User>(Messages.WrongPassword);
        }

        return new SuccessDataResult<User>(userToCheck.Data,Messages.SuccessfulLogin);

    }

    [ValidationAspect(typeof(UserValidator))]
    public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
    {
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password,out var passwordHash,out var passwordSalt);
        
        var user = new User
        {
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            Email = userForRegisterDto.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };

        _userService.Add(user);
        return new SuccessDataResult<User>(user,Messages.SuccessfulRegister);
    }

    public IDataResult<User> IsUserExists(string email)
    {
        var userExists = _userService.GetByEmail(email);
        if (!userExists.Success)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        return new SuccessDataResult<User>(userExists.Data,Messages.UserAlreadyExists);
    }

    public IResult IsUserNotExists(string email)
    {
        var userExists = _userService.GetByEmail(email);
        if (!userExists.Success)
        {
            return new SuccessDataResult<User>(Messages.UserNotFound);
        }

        return new ErrorResult(Messages.UserAlreadyExists);
    }

    public IDataResult<AccessToken> CreateToken(User user)
    {
        var claims = _userService.GetClaims(user);
        AccessToken token = _tokenHelper.CreateJwtToken(user,claims.Data);
        
        if (token == null)
        {
            return new ErrorDataResult<AccessToken>(Messages.TokenNotCreated);
        }

        return new SuccessDataResult<AccessToken>(token,Messages.TokenCreated);
    }
}