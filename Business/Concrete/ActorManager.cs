using Business.Abstract;
using Core.Utilities.Business;
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
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<IEnumerable<Actor>>();

        return new SuccessDataResult<IEnumerable<Actor>>(_actorDal.GetAll());
    }

    public IDataResult<Actor?> GetByActorId(int actorId)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<Actor>();

        return new SuccessDataResult<Actor?>(_actorDal.Get(a => a.ActorId == actorId));
    }

    public IResult Add(Actor actor)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _actorDal.Add(actor);
        return new SuccessResult();
    }

    public IResult Update(Actor actor)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();
        
        
        _actorDal.Update(actor);
        return new SuccessResult();
    }

    public IResult Delete(Actor actor)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();
        
        _actorDal.Delete(actor);
        return new SuccessResult();
    }
}