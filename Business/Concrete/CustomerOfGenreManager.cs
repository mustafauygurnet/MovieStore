using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerOfGenreManager : ICustomerOfGenreService
{
    private readonly ICustomerOfGenreDal _customerOfGenreDal;

    public CustomerOfGenreManager(ICustomerOfGenreDal customerOfGenreDal)
    {
        _customerOfGenreDal = customerOfGenreDal;
    }

    public IDataResult<List<CustomerOfGenre>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<List<CustomerOfGenre>>();

        return new SuccessDataResult<List<CustomerOfGenre>>(_customerOfGenreDal.GetAll());
    }

    public IDataResult<CustomerOfGenre> GetById(int id)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<CustomerOfGenre>();
        
        return new SuccessDataResult<CustomerOfGenre>(_customerOfGenreDal.Get(a=>a.Id == id));
    }

    public IResult Add(CustomerOfGenre customerOfGenre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfGenreDal.Add(customerOfGenre);
        return new SuccessResult();
    }

    public IResult Update(CustomerOfGenre customerOfGenre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfGenreDal.Update(customerOfGenre);
        return new SuccessResult();
    }

    public IResult Delete(CustomerOfGenre customerOfGenre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _customerOfGenreDal.Delete(customerOfGenre);
        return new SuccessResult();
    }
}