using Shared.Dtos;

namespace API.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDto dto);
        Task DeleteOrder(Guid id);
        Task<OrderDto> GetOrder(Guid id);
        Task<List<OrderDto>> GetOrders();
        Task UpdateOrder(OrderDto dto);
    }
}