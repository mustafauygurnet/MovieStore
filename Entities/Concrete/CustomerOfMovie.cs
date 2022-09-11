using Core.Entities.Abstract;

namespace Entities.Concrete;

public class CustomerOfMovie : IEntity
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int MovieId { get; set; }
}