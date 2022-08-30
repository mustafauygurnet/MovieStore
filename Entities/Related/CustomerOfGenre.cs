using Core.Entities.Abstract;

namespace Entities.Related;

public class CustomerOfGenre : IEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int GenreId { get; set; }
}