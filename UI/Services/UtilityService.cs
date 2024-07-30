using System.Net.Http.Json;
using UI.Dtos.Utilities;
using UI.Services.Interfaces;

namespace UI.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly HttpClient _httpClient;

        public UtilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ManageOrderUtilitiesDto> GetManageOrderUtilities()
        {
            return await _httpClient.GetFromJsonAsync<ManageOrderUtilitiesDto?>("api/utilities/manage-order");
        }

        public async Task<ManageOrderLineUtilitiesDto> GetManageOrderLineUtilities(Guid orderId)
        {
            return await _httpClient.GetFromJsonAsync<ManageOrderLineUtilitiesDto?>($"api/utilities/manage-order-line/{orderId}");
        }
    }
}
