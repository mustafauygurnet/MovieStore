using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public IDataResult<User> GetByUserId(int userId)
    {
        return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId == userId));
    }

    public IDataResult<User> GetByEmail(string email)
    {
        return new SuccessDataResult<User>(_userDal.Get(u=>u.Email == email));
    }

    public IDataResult<IEnumerable<OperationClaimOfUserDto>> GetClaims(User user)
    {
        return new SuccessDataResult<IEnumerable<OperationClaimOfUserDto>>(_userDal.GetClaims(user));
    }

    public IResult Add(User user)
    {
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IResult Update(User user)
    {
        _userDal.Update(user);
        return new SuccessResult();
    }

    public IResult Delete(User user)
    {
        _userDal.Delete(user);
        return new SuccessResult();
    }
}