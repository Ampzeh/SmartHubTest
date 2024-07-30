using System.Net.Http.Json;
using UI.Dtos;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly HttpClient _httpClient;
        private readonly IHelperService _helperService;

        public OrderLineService(HttpClient httpClient, IHelperService helperService)
        {
            _httpClient = httpClient;
            _helperService = helperService;
        }
        public async Task<List<OrderLineDto>> GetOrderLines(Guid orderId)
        {
            return await _httpClient.GetFromJsonAsync<List<OrderLineDto>>($"api/orderline/list/{orderId}");
        }

        public async Task<OrderLineDto> GetOrderLine(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<OrderLineDto>($"api/orderline/{id}");
        }

        public async Task CreateOrderLine(OrderLineDto dto)
        {
            await _helperService.HandleHttpResponse(await _httpClient.PostAsJsonAsync("api/orderline", dto));
        }

        public async Task UpdateOrderLine(OrderLineDto dto)
        {
            await _helperService.HandleHttpResponse(await _httpClient.PutAsJsonAsync("api/orderline", dto));
        }

        public async Task DeleteOrderLine(Guid id)
        {
            await _helperService.HandleHttpResponse(await _httpClient.DeleteAsync($"api/orderline/{id}"));
        }
    }
}
