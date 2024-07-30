using API.DataAccess;
using API.Extensions;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;
using Shared.Models;

namespace API.Services
{
    public class OrderLineService : IOrderLineService
    {
        private readonly MainContext _context;

        public OrderLineService(MainContext context)
        {
            _context = context;
        }

        public async Task<List<OrderLineDto>> GetOrderLines(Guid orderId)
        {
            return await _context.OrderLine
                .Include(_ => _.ProductType)
                .Where(_ => !_.IsDeleted && _.OrderId == orderId)
                .Select(_ => new OrderLineDto(_))
                .ToListAsync();
        }

        public async Task<OrderLineModel> GetOrderLineModel(Guid id)
        {
            return await _context.OrderLine.FirstOrDefaultAsync(_ => !_.IsDeleted && _.Id == id);
        }

        public async Task<OrderLineDto> GetOrderLine(Guid id)
        {
            var orderLines = await GetOrderLineModel(id);

            if (orderLines != null)
                return new OrderLineDto(orderLines);

            return new OrderLineDto();
        }

        public async Task CreateOrderLine(OrderLineDto dto)
        {
            await _context.AddAsync(dto.MapToModel());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderLine(OrderLineDto dto)
        {
            var orderLines = await GetOrderLineModel((Guid)dto.Id!);
            _context.OrderLine.Update(dto.MapToModel(orderLines));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderLine(Guid id)
        {
            await _context.OrderLine
            .Where(_ => _.Id == id)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsDeleted, true));
        }
    }
}
