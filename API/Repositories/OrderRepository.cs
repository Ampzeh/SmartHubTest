using API.DataAccess;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MainContext _context;

        public OrderRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<OrderModel>> GetOrders()
        {
            return await Task.FromResult(_context.Order
                .Include(_ => _.Type)
                .Include(_ => _.Status)
                .Where(_ => !_.IsDeleted));
        }

        public async Task<OrderModel> GetOrder(Guid id)
        {
            return await _context.Order.FirstOrDefaultAsync(_ => !_.IsDeleted && _.Id == id);
        }

        public async Task CreateOrder(OrderModel model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(OrderModel model)
        {
            _context.Order.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Guid id)
        {
            await _context.Order
            .Where(_ => _.Id == id)
            .ExecuteUpdateAsync(u => u.SetProperty(p => p.IsDeleted, true));
        }
    }
}
