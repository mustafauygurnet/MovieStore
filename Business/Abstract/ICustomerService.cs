using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomerService
{
    IDataResult<IEnumerable<Customer>> GetAll();
    IDataResult<Customer?> GetByCustomerId(int customerId);
    IResult Add(Customer customer);
    IResult Update(Customer customer);
    IResult Delete(Customer customer);
}