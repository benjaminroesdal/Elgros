using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IOrderFacade
    {
        Task<OrderModel> CreateOrder(OrderModel orderModel);
        Task<OrderModel> GetOrder(int orderId);
    }
}
