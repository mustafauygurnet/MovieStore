using Core.Entities.Abstract;

namespace Entities.Concrete;

public class GenreOfMovie : IEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int GenreId { get; set; }
}