using ElgrosWeb.Shared.Models;
using System.Net.Http.Json;

namespace ElgrosWeb.Client.Services
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public async Task<OrderModel> GetOrder(int orderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Order/GetOrderById?orderId={orderId}");
                var orderModel = await response.Content.ReadFromJsonAsync<OrderModel>();
                return orderModel;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OrderModel> PostOrder(OrderModel order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Order/PostOrder", order);
                var orderModel = await response.Content.ReadFromJsonAsync<OrderModel>();
                return orderModel;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        /// <returns>orderModel</returns>
        public async Task<OrderModel> FinalizeOrder(OrderModel order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Order/FinalizeOrder", order);
                var orderModel = await response.Content.ReadFromJsonAsync<OrderModel>();
                return orderModel;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
