using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public IDataResult<IEnumerable<Order>> GetAll()
    {
        return new SuccessDataResult<IEnumerable<Order>>(_orderDal.GetAll());
    }

    public IDataResult<Order> GetByOrderId(int orderId)
    {
        return new SuccessDataResult<Order>();
    }

    public IResult Add(Order order)
    {
        _orderDal.Add(order);
        return new SuccessResult();
    }

    public IResult Update(Order order)
    {
        _orderDal.Update(order);
        return new SuccessResult();
    }

    public IResult Delete(Order order)
    {
        _orderDal.Delete(order);
        return new SuccessResult();
    }
}