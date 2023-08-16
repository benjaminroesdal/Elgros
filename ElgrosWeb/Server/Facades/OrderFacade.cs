using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Server.Repositories.Interfaces;
using ElgrosWeb.Shared.Dao;
using ElgrosWeb.Shared.Enums;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderRepository _orderRepository;
        public OrderFacade(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<OrderModel> CreateOrder(OrderModel orderModel) =>
            _orderRepository.CreateAsync(orderModel);

        public Task<OrderModel> GetOrder(int orderId) => 
            _orderRepository.GetAsync(orderId);
    }
}
