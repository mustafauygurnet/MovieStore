using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerOfMovieDal : EfEntityRepositoryBase<CustomerOfMovie,MovieStoreDbContext>, ICustomerOfMovieDal
{
    
}