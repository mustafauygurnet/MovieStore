using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class DirectorOfMovieManager : IDirectorOfMovieService
{
    private readonly IDirectorOfMovieDal _directorOfMovieDal;

    public DirectorOfMovieManager(IDirectorOfMovieDal directorOfMovieDal)
    {
        _directorOfMovieDal = directorOfMovieDal;
    }

    public IDataResult<List<DirectorOfMovie>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<List<DirectorOfMovie>>();

        return new SuccessDataResult<List<DirectorOfMovie>>(_directorOfMovieDal.GetAll());
    }

    public IDataResult<DirectorOfMovie> GetById(int id)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<DirectorOfMovie>();
        
        return new SuccessDataResult<DirectorOfMovie>(_directorOfMovieDal.Get(a=>a.Id == id));
    }

    public IResult Add(DirectorOfMovie directorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _directorOfMovieDal.Add(directorOfMovie);
        return new SuccessResult();
    }

    public IResult Update(DirectorOfMovie directorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _directorOfMovieDal.Update(directorOfMovie);
        return new SuccessResult();
    }

    public IResult Delete(DirectorOfMovie directorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _directorOfMovieDal.Delete(directorOfMovie);
        return new SuccessResult();
    }
}