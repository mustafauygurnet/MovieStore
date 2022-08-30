using Core.Entities.Abstract;

namespace Entities.Related;

public class DirectorOfMovie : IEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int DirectorId { get; set; }
}