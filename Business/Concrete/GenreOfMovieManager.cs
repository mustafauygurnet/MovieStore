using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class GenreOfMovieManager : IGenreOfMovieService
{
    private readonly IGenreOfMovieDal _genreOfMovieDal;

    public GenreOfMovieManager(IGenreOfMovieDal genreOfMovieDal)
    {
        _genreOfMovieDal = genreOfMovieDal;
    }

    public IDataResult<List<GenreOfMovie>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<List<GenreOfMovie>>();

        return new SuccessDataResult<List<GenreOfMovie>>(_genreOfMovieDal.GetAll());
    }

    public IDataResult<GenreOfMovie> GetById(int id)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<GenreOfMovie>();
        
        return new SuccessDataResult<GenreOfMovie>(_genreOfMovieDal.Get(a=>a.Id == id));
    }

    public IResult Add(GenreOfMovie genreOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreOfMovieDal.Add(genreOfMovie);
        return new SuccessResult();
    }

    public IResult Update(GenreOfMovie genreOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreOfMovieDal.Update(genreOfMovie);
        return new SuccessResult();
    }

    public IResult Delete(GenreOfMovie genreOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreOfMovieDal.Delete(genreOfMovie);
        return new SuccessResult();
    }
}