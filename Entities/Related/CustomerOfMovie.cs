using Core.Entities.Abstract;

namespace Entities.Related;

public class CustomerOfMovie : IEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MovieId { get; set; }
}