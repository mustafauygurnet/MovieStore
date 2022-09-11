using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class GenreManager : IGenreService
{
    private readonly IGenreDal _genreDal;

    public GenreManager(IGenreDal genreDal)
    {
        _genreDal = genreDal;
    }

    public IDataResult<IEnumerable<Genre>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<IEnumerable<Genre>>();
        
        return new SuccessDataResult<IEnumerable<Genre>>(_genreDal.GetAll());
    }

    public IDataResult<Genre?> GetByGenreId(int genreId)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<Genre?>();
        
        return new SuccessDataResult<Genre?>(_genreDal.Get(g => g.GenreId == genreId));
    }

    public IResult Add(Genre genre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreDal.Add(genre);
        return new SuccessResult();
    }

    public IResult Update(Genre genre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreDal.Update(genre);
        return new SuccessResult();
    }

    public IResult Delete(Genre genre)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _genreDal.Delete(genre);
        return new SuccessResult();
    }
}