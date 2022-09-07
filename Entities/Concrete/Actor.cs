using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Actor: IEntity
{
    public int ActorId { get; set; }
    public string ActorName { get; set; }
    public IEnumerable<int> FilmIds { get; set; }
}