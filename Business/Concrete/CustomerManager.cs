using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IDataResult<IEnumerable<Customer>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<IEnumerable<Customer>>();
        
        return new SuccessDataResult<IEnumerable<Customer>>(_customerDal.GetAll());
    }

    public IDataResult<Customer?> GetByCustomerId(int customerId)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<Customer?>();

        return new SuccessDataResult<Customer?>(_customerDal.Get(c => c.CustomerId == customerId));
    }

    public IResult Add(Customer customer)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerDal.Add(customer);
        return new SuccessResult();
    }

    public IResult Update(Customer customer)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerDal.Update(customer);
        return new SuccessResult();
    }

    public IResult Delete(Customer customer)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerDal.Delete(customer);
        return new SuccessResult();
    }
}