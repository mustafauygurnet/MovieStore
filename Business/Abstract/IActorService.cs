using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IActorService
{
    IDataResult<IEnumerable<Actor>> GetAll();
    IDataResult<Actor?> GetByActorId(int actorId);
    IResult Add(Actor actor);
    IResult Update(Actor actor);
    IResult Delete(Actor actor);
}