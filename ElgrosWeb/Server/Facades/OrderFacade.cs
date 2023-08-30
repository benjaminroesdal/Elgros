using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Server.Repositories.Interfaces;
using ElgrosWeb.Shared.Models;

namespace ElgrosWeb.Server.Facades
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentFacade _paymentFacade;
        private readonly INotificationFacade _notificationFacade;
        public OrderFacade(IOrderRepository orderRepository, IPaymentFacade paymentFacade, INotificationFacade notificationFacade)
        {
            _orderRepository = orderRepository;
            _paymentFacade = paymentFacade;
            _notificationFacade = notificationFacade;
        }

        public Task<OrderModel> CreateOrder(OrderModel orderModel) =>
            _orderRepository.CreateAsync(orderModel);

        public async Task<OrderModel> FinalizeOrder(OrderModel orderModel)
        {
            var isPaymentReceived = _paymentFacade.CreditCardPayment();
            if (!isPaymentReceived)
            {
                throw new Exception("Payment not received");
            }
            var order = await _orderRepository.FinalizeOrder(orderModel.Id);
            // await _notificationFacade.SendEmail($"Ordrebekræftelse på ordre:{orderModel.Id}. Du kan se din ordre på følgende link: URLPLACEHOLDER", orderModel.User.Email);
            return order;
        }

        public Task<OrderModel> GetOrder(int orderId) => 
            _orderRepository.GetAsync(orderId);
    }
}
