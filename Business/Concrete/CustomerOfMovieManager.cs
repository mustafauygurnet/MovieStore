using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerOfMovieManager : ICustomerOfMovieService
{
    private readonly ICustomerOfMovieDal _customerOfMovieDal;

    public CustomerOfMovieManager(ICustomerOfMovieDal customerOfMovieDal)
    {
        _customerOfMovieDal = customerOfMovieDal;
    }

    public IDataResult<List<CustomerOfMovie>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<List<CustomerOfMovie>>();

        return new SuccessDataResult<List<CustomerOfMovie>>(_customerOfMovieDal.GetAll());
    }

    public IDataResult<CustomerOfMovie> GetById(int id)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<CustomerOfMovie>();
        
        return new SuccessDataResult<CustomerOfMovie>(_customerOfMovieDal.Get(a=>a.Id == id));
    }

    public IResult Add(CustomerOfMovie customerOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfMovieDal.Add(customerOfMovie);
        return new SuccessResult();
    }

    public IResult Update(CustomerOfMovie customerOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfMovieDal.Update(customerOfMovie);
        return new SuccessResult();
    }

    public IResult Delete(CustomerOfMovie customerOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfMovieDal.Delete(customerOfMovie);
        return new SuccessResult();
    }
}