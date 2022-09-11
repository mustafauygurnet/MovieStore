using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IGenreOfMovieService
{
    IDataResult<List<GenreOfMovie>> GetAll();
    IDataResult<GenreOfMovie> GetById(int id);
    IResult Add(GenreOfMovie genreOfMovie);
    IResult Update(GenreOfMovie genreOfMovie);
    IResult Delete(GenreOfMovie genreOfMovie);
}