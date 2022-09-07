using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IOrderService
{
    IDataResult<IEnumerable<Order>> GetAll();
    IDataResult<Order> GetByOrderId(int orderId);
    IResult Add(Order order);
    IResult Update(Order order);
    IResult Delete(Order order);
}