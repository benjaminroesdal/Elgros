using ElgrosWeb.Server.Data.Models;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IOrderFacade
    {
        Task<OrderModel> CreateOrder(OrderDao orderDao);
        Task<OrderModel> GetOrger(int orderId);
    }
}
