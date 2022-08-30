using Core.Entities.Abstract;

namespace Entities.Related;

public class GenreOfMovie : IEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int GenreId { get; set; }
}