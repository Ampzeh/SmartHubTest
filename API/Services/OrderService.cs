using API.Extensions;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetOrders()
        {
            var result = await _orderRepository.GetOrders();

            return await result
                .Select(_ => new OrderDto(_))
                .ToListAsync();
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            var order = await _orderRepository.GetOrder(id);

            if (order != null)
                return new OrderDto(order);

            return new OrderDto();
        }

        public async Task CreateOrder(OrderDto dto)
        {
            await _orderRepository.CreateOrder(dto.MapToModel());
        }

        public async Task UpdateOrder(OrderDto dto)
        {
            var order = await _orderRepository.GetOrder((Guid)dto.Id!);
            await _orderRepository.UpdateOrder(dto.MapToModel(order));
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }
    }
}
