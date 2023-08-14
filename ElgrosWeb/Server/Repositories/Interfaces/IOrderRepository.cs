using ElgrosWeb.Server.Data.Models;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderModel> CreateAsync(OrderDao order);
        Task<OrderModel> GetAsync(int id);
    }
}
