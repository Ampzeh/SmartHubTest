using UI.Dtos;

namespace UI.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderDto dto);
        Task DeleteOrder(Guid Id);
        Task<OrderDto> GetOrder(Guid Id);
        Task<List<OrderDto>> GetOrders();
        Task UpdateOrder(OrderDto dto);
    }
}