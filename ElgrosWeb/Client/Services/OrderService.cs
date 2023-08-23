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
