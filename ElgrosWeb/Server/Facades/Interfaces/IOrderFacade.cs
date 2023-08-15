using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IOrderFacade
    {
        Task<OrderModel> CreateOrder(OrderDao orderDao);
        Task<OrderModel> GetOrder(int orderId);
    }
}
