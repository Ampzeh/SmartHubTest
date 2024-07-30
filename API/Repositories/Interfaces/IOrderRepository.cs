using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(OrderModel model);
        Task DeleteOrder(Guid id);
        Task<OrderModel> GetOrder(Guid id);
        Task<IQueryable<OrderModel>> GetOrders();
        Task UpdateOrder(OrderModel model);
    }
}