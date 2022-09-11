using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class DirectorManager : IDirectorService
{
    private readonly IDirectorDal _directorDal;

    public DirectorManager(IDirectorDal directorDal)
    {
        _directorDal = directorDal;
    }

    public IDataResult<IEnumerable<Director>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<IEnumerable<Director>>();
        
        return new SuccessDataResult<IEnumerable<Director>>(_directorDal.GetAll());
    }

    public IDataResult<Director?> GetByDirectorId(int directorId)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<Director?>();
        
        return new SuccessDataResult<Director?>(_directorDal.Get(d => d.DirectorId == directorId));
    }

    public IResult Add(Director director)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();
        
        _directorDal.Add(director);
        return new SuccessResult();
    }

    public IResult Update(Director director)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();
        
        _directorDal.Update(director);
        return new SuccessResult();
    }

    public IResult Delete(Director director)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();
        
        _directorDal.Delete(director);
        return new SuccessResult();
    }
}