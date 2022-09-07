using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IDirectorService
{
    IDataResult<IEnumerable<Director>> GetAll();
    IDataResult<Director?> GetByDirectorId(int directorId);
    IResult Add(Director director);
    IResult Update(Director director);
    IResult Delete(Director director);
}