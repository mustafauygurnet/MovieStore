using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;

namespace DataAccess.Abstract;

public interface IUserDal : IEntityRepository<User>
{
    IEnumerable<OperationClaimOfUserDto> GetClaims(User user);
}