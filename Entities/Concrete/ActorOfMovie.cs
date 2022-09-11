using Core.Entities.Abstract;

namespace Entities.Concrete;

public class ActorOfMovie : IEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int ActorId { get; set; }
}