using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomerOfMovieService
{
    IDataResult<List<CustomerOfMovie>> GetAll();
    IDataResult<CustomerOfMovie> GetById(int id);
    IResult Add(CustomerOfMovie customerOfMovie);
    IResult Update(CustomerOfMovie customerOfMovie);
    IResult Delete(CustomerOfMovie customerOfMovie);
}