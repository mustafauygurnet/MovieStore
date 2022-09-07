using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal : EfEntityRepositoryBase<User, MovieStoreDbContext>, IUserDal
{
    public IEnumerable<OperationClaimOfUserDto> GetClaims(User user)
    {
        using var context = new MovieStoreDbContext();

        var claims = from userOperationClaim in context.UserOperationClaims
            join operationClaim in context.OperationClaims
                on userOperationClaim.OperationClaimId equals operationClaim.OperationClaimId
            where userOperationClaim.UserId == user.UserId
            select new OperationClaimOfUserDto
            {
                Id = operationClaim.OperationClaimId,
                Name = operationClaim.OperationClaimName
            };

        return claims.ToList();
    }
}