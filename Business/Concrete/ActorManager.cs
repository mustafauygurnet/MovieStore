using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ActorManager : IActorService
{
    private readonly IActorDal _actorDal;

    public ActorManager(IActorDal actorDal)
    {
        _actorDal = actorDal;
    }

    public IDataResult<IEnumerable<Actor>> GetAll()
    {
        return new SuccessDataResult<IEnumerable<Actor>>(_actorDal.GetAll());
    }

    public IDataResult<Actor?> GetByActorId(int actorId)
    {
        return new SuccessDataResult<Actor?>(_actorDal.Get(a => a.ActorId == actorId));
    }

    public IResult Add(Actor actor)
    {
        _actorDal.Add(actor);
        return new SuccessResult();
    }

    public IResult Update(Actor actor)
    {
        _actorDal.Update(actor);
        return new SuccessResult();
    }

    public IResult Delete(Actor actor)
    {
        _actorDal.Delete(actor);
        return new SuccessResult();
    }
}