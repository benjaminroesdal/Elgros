using ElgrosWeb.Server.Facades.Interfaces;
using ElgrosWeb.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElgrosWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade _orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<OrderModel> GetOrder(int orderId)
        {
            return await _orderFacade.GetOrder(orderId);
        }

        [HttpPost]
        [Route("PostOrder")]
        public async Task<OrderModel> CreateOrder(OrderModel orderModel)
        {
            return await _orderFacade.CreateOrder(orderModel);
        }
    }
}
