using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Creates the provided order in the database
        /// </summary>
        /// <param name="orderModel">Order to create in database</param>
        /// <returns>Order created in database</returns>
        Task<OrderModel> CreateAsync(OrderModel orderModel);
        /// <summary>
        /// Sets paymentstatus on order with provided orderId to Success and saves the order.
        /// </summary>
        /// <param name="orderId">OrderId on order to finalize</param>
        /// <returns>Finalized order</returns>
        Task<OrderModel> FinalizeOrder(int orderId);
        /// <summary>
        /// Gets the order from DB with the provided orderId
        /// </summary>
        /// <param name="id">OrderId to find order on</param>
        /// <returns>Order found on provided orderId</returns>
        Task<OrderModel> GetAsync(int id);
    }
}
