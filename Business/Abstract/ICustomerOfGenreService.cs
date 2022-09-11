using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomerOfGenreService
{
    IDataResult<List<CustomerOfGenre>> GetAll();
    IDataResult<CustomerOfGenre> GetById(int id);
    IResult Add(CustomerOfGenre customerOfGenre);
    IResult Update(CustomerOfGenre customerOfGenre);
    IResult Delete(CustomerOfGenre customerOfGenre);
}