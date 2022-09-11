using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IActorOfMovieService
{
    IDataResult<List<ActorOfMovie>> GetAll();
    IDataResult<ActorOfMovie> GetById(int id);
    IResult Add(ActorOfMovie actorOfMovie);
    IResult Update(ActorOfMovie actorOfMovie);
    IResult Delete(ActorOfMovie actorOfMovie);
}