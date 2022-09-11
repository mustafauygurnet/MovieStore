using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IDirectorOfMovieService
{
    IDataResult<List<DirectorOfMovie>> GetAll();
    IDataResult<DirectorOfMovie> GetById(int id);
    IResult Add(DirectorOfMovie directorOfMovie);
    IResult Update(DirectorOfMovie directorOfMovie);
    IResult Delete(DirectorOfMovie directorOfMovie);
}