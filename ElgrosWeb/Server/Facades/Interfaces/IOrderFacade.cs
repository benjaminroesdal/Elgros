using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades.Interfaces
{
    public interface IOrderFacade
    {
        /// <summary>
        /// Creates and saves an order based on the provided model
        /// </summary>
        /// <param name="orderModel">order to save</param>
        /// <returns>The saved order model</returns>
        Task<OrderModel> CreateOrder(OrderModel orderModel);
        /// <summary>
        /// Gets an order based on the provided orderId
        /// </summary>
        /// <param name="orderId">The id associated with the desired order</param>
        /// <returns>Ordermodel of the requested order</returns>
        Task<OrderModel> GetOrder(int orderId);
        /// <summary>
        /// Finalizes order based on payment, and sends order confirmation in case of success.
        /// </summary>
        /// <param name="orderModel">Order to finalize</param>
        /// <returns>Finalized order</returns>
        Task<OrderModel> FinalizeOrder(OrderModel orderModel);
    }
}
