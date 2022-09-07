using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MovieManager : IMovieService
{
    private readonly IMovieDal _movieDal;

    public MovieManager(IMovieDal movieDal)
    {
        _movieDal = movieDal;
    }

    public IDataResult<IEnumerable<Movie>> GetAll()
    {
        return new SuccessDataResult<IEnumerable<Movie>>(_movieDal.GetAll());
    }

    public IDataResult<Movie?> GetByMovieId(int movieId)
    {
        return new SuccessDataResult<Movie?>(_movieDal.Get(m=>m.MovieId == movieId));
    }

    public IResult Add(Movie movie)
    {
        _movieDal.Add(movie);
        return new SuccessResult();
    }

    public IResult Update(Movie movie)
    {
        _movieDal.Update(movie);
        return new SuccessResult();
    }

    public IResult Delete(Movie movie)
    {
        _movieDal.Delete(movie);
        return new SuccessResult();
    }
}