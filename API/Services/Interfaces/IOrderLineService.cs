using Shared.Dtos;
using Shared.Models;

namespace API.Services.Interfaces
{
    public interface IOrderLineService
    {
        Task CreateOrderLine(OrderLineDto dto);
        Task DeleteOrderLine(Guid id);
        Task<OrderLineDto> GetOrderLine(Guid id);
        Task<OrderLineModel> GetOrderLineModel(Guid id);
        Task<List<OrderLineDto>> GetOrderLines(Guid orderId);
        Task UpdateOrderLine(OrderLineDto dto);
    }
}