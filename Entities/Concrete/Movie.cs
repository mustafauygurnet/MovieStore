using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Movie : IEntity
{
    public int MovieId { get; set; }
    public string MovieName { get; set; }
    public int MovieYear { get; set; }
    public decimal Price { get; set; }
}