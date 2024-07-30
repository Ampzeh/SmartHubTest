using Shared.Dtos;

namespace UI.Services.Interfaces
{
    public interface IOrderLineService
    {
        Task CreateOrderLine(OrderLineDto dto);
        Task DeleteOrderLine(Guid id);
        Task<OrderLineDto> GetOrderLine(Guid id);
        Task<List<OrderLineDto>> GetOrderLines(Guid orderId);
        Task UpdateOrderLine(OrderLineDto dto);
    }
}