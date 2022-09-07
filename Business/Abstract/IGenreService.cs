using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IGenreService
{
    IDataResult<IEnumerable<Genre>> GetAll();
    IDataResult<Genre?> GetByGenreId(int genreId);
    IResult Add(Genre genre);
    IResult Update(Genre genre);
    IResult Delete(Genre genre);
}