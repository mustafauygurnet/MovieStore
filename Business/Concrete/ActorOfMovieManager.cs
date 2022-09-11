using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ActorOfMovieManager : IActorOfMovieService
{
    private readonly IActorOfMovieDal _actorOfMovieDal;

    public ActorOfMovieManager(IActorOfMovieDal actorOfMovieDal)
    {
        _actorOfMovieDal = actorOfMovieDal;
    }

    public IDataResult<List<ActorOfMovie>> GetAll()
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<List<ActorOfMovie>>();

        return new SuccessDataResult<List<ActorOfMovie>>(_actorOfMovieDal.GetAll());
    }

    public IDataResult<ActorOfMovie> GetById(int id)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorDataResult<ActorOfMovie>();
        
        return new SuccessDataResult<ActorOfMovie>(_actorOfMovieDal.Get(a=>a.Id == id));
    }

    public IResult Add(ActorOfMovie actorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _actorOfMovieDal.Add(actorOfMovie);
        return new SuccessResult();
    }

    public IResult Update(ActorOfMovie actorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _actorOfMovieDal.Update(actorOfMovie);
        return new SuccessResult();
    }

    public IResult Delete(ActorOfMovie actorOfMovie)
    {
        var result = BusinessRules.Run();
        if (result.Success is false)
            return new ErrorResult();

        _actorOfMovieDal.Delete(actorOfMovie);
        return new SuccessResult();
    }
}