using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades
{
    public class OrderFacade : IOrderFacade
    {
        public Task<OrderModel> CreateOrder(OrderDao orderDao)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
