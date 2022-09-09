using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<User> GetByUserId(int userId);
    IDataResult<User> GetByEmail(string email);
    IDataResult<IEnumerable<OperationClaimOfUserDto>> GetClaims(User user);
    IResult Add(User user);
    IResult Update(User user);
    IResult Delete(User user);
}