using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IMovieService
{
    IDataResult<IEnumerable<Movie>> GetAll();
    IDataResult<Movie?> GetByMovieId(int movieId);
    IResult Add(Movie movie);
    IResult Update(Movie movie);
    IResult Delete(Movie movie);
}