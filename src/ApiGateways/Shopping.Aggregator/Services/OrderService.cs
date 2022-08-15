using Shopping.Aggregator.Models;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            return await _client.GetFromJsonAsync<List<OrderResponseModel>>($"/api/v1/Order/{userName}") ?? new List<OrderResponseModel>();
        }
    }
}
