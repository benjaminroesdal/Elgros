using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderModel> CreateAsync(OrderModel orderModel);
        Task<OrderModel> FinalizeOrder(int orderId);
        Task<OrderModel> GetAsync(int id);
    }
}
