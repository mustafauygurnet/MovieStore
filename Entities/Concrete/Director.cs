using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Director : IEntity
{
    public int DirectorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IEnumerable<int> FilmIds { get; set; }
}