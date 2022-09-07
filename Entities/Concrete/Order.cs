using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Order : IEntity
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public int FilmId { get; set; }
    public DateTime Date { get; set; }
}