using Core.Entities.Abstract;

namespace Entities.Concrete;

public class DirectorOfMovie : IEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int DirectorId { get; set; }
}