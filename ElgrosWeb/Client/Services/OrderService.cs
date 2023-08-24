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

        public async Task PostOrder(OrderModel order)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/Order/PostOrder", order);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
