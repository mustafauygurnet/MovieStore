using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Customer: IEntity
{
    public int CustomerId { get; set; }
    public int UserId { get; set; }
    public IEnumerable<int> FilmIds { get; set; }
    public IEnumerable<int> FavoruiteGenreIds { get; set; }
}