using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Actor : IEntity
{
    public int ActorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}