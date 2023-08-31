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

        /// <summary>
        /// Gets order based on provided orderId
        /// </summary>
        /// <param name="orderId">OrderId to find order on</param>
        /// <returns>Order found on orderId</returns>
        [HttpGet]
        [Route("GetOrderById")]
        public async Task<OrderModel> GetOrder(int orderId)
        {
            return await _orderFacade.GetOrder(orderId);
        }

        /// <summary>
        /// Creates an order based on provided model
        /// </summary>
        /// <param name="orderModel">OrderModel to create in DB</param>
        /// <returns>Created order</returns>
        [HttpPost]
        [Route("PostOrder")]
        public async Task<OrderModel> CreateOrder([FromBody] OrderModel orderModel)
        {
            return await _orderFacade.CreateOrder(orderModel);
        }

        /// <summary>
        /// Finalize provided order and send confirmation email
        /// </summary>
        /// <param name="orderModel">Order to finalize</param>
        /// <returns>Finalized order</returns>
        [HttpPost]
        [Route("FinalizeOrder")]
        public async Task<OrderModel> FinalizeOrder([FromBody] OrderModel orderModel)
        {
            return await _orderFacade.FinalizeOrder(orderModel);
        }
    }
}
