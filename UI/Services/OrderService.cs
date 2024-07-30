using System.Net.Http.Json;
using UI.Dtos;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IHelperService _helperService;

        public OrderService(HttpClient httpClient, IHelperService helperService)
        {
            _httpClient = httpClient;
            _helperService = helperService;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDto>>("api/order/list");
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDto>($"api/order/{id}");
        }

        public async Task CreateOrder(OrderDto dto)
        {
            await _helperService.HandleHttpResponse(await _httpClient.PostAsJsonAsync("api/order", dto));
        }

        public async Task UpdateOrder(OrderDto dto)
        {
            await _helperService.HandleHttpResponse(await _httpClient.PutAsJsonAsync("api/order", dto));
        }

        public async Task DeleteOrder(Guid id)
        {
            await _helperService.HandleHttpResponse(await _httpClient.DeleteAsync($"api/order/{id}"));
        }
    }
}
