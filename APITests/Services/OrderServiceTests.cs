using API.Dtos;
using API.Models;
using API.Repositories.Interfaces;
using Moq;

namespace API.Services.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        static Mock<IOrderRepository> _mockRepository = new Mock<IOrderRepository>();
        static OrderService _orderService = new OrderService(_mockRepository.Object);

        [TestMethod]
        public async Task GetOrder_ReturnsOrderDto_WhenOrderExists()
        {
            var orderId = Guid.NewGuid();
            var order = new OrderModel()
            {
                Id = orderId,
                OrderNumber = "aa",
                CustomerName = "a",
                OrderDate = DateTime.Parse("2024-07-30 00:00:00.0000000"),
                CreatedDate = DateTime.Parse("2024-07-29 18:53:55.4870000"),
                TypeId = Guid.Parse("33e8cd0c-c091-450b-8d99-0d91382a67de"),
                StatusId = Guid.Parse("99f5bce5-40d4-41f2-939c-02d66d2d0cfb"),
                IsDeleted = false,
            };

            var expected = new OrderDto(order);

            _mockRepository.Setup(repo => repo.GetOrder(orderId)).ReturnsAsync(order);


            var result = await _orderService.GetOrder(orderId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<OrderDto>(result);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.OrderNumber, result.OrderNumber);
            Assert.AreEqual(expected.CustomerName, result.CustomerName);
            Assert.AreEqual(expected.OrderDate, result.OrderDate);
            Assert.AreEqual(expected.CreatedDate, result.CreatedDate);
            Assert.AreEqual(expected.TypeId, result.TypeId);
            Assert.AreEqual(expected.StatusId, result.StatusId);
            Assert.AreEqual(expected.IsDeleted, result.IsDeleted);
        }

        [TestMethod]
        public async Task GetOrder_ReturnsEmptyOrderDto_WhenOrderDoesNotExist()
        {
            var orderId = Guid.NewGuid();
            var order = new OrderModel()
            {
                Id = orderId,
                OrderNumber = "aa",
                CustomerName = "a",
                OrderDate = DateTime.Parse("2024-07-30 00:00:00.0000000"),
                CreatedDate = DateTime.Parse("2024-07-29 18:53:55.4870000"),
                TypeId = Guid.Parse("33e8cd0c-c091-450b-8d99-0d91382a67de"),
                StatusId = Guid.Parse("99f5bce5-40d4-41f2-939c-02d66d2d0cfb"),
                IsDeleted = false,
            };

            var expected = new OrderDto();

            _mockRepository.Setup(repo => repo.GetOrder(orderId)).ReturnsAsync((OrderModel)null);


            var result = await _orderService.GetOrder(orderId);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType<OrderDto>(result);

            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.OrderNumber, result.OrderNumber);
            Assert.AreEqual(expected.CustomerName, result.CustomerName);
            Assert.AreEqual(expected.OrderDate, result.OrderDate);
            Assert.AreEqual(expected.CreatedDate, result.CreatedDate);
            Assert.AreEqual(expected.TypeId, result.TypeId);
            Assert.AreEqual(expected.StatusId, result.StatusId);
            Assert.AreEqual(expected.IsDeleted, result.IsDeleted);
        }

        [TestMethod]
        public async Task DeleteOrder_CallsRepositoryDeleteOnce()
        {
            var id = Guid.NewGuid();

            _mockRepository.Setup(repo => repo.DeleteOrder(id)).Returns(Task.CompletedTask);

            await _orderService.DeleteOrder(id);

            _mockRepository.Verify(repo => repo.DeleteOrder(id), Times.Once);
        }

        [TestMethod]
        public async Task UpdateOrder_CallsRepositoryUpdateOnce()
        {
            var model = new OrderModel
            {
                Id = Guid.NewGuid(),
                OrderNumber = "123",
                CustomerName = "John Doe",
                OrderDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                TypeId = Guid.NewGuid(),
                StatusId = Guid.NewGuid(),
                IsDeleted = false
            };

            var dto = new OrderDto(model);

            _mockRepository.Setup(repo => repo.UpdateOrder(model)).Returns(Task.CompletedTask);
            _mockRepository.Setup(repo => repo.GetOrder(model.Id)).ReturnsAsync(model);

            await _orderService.UpdateOrder(dto);

            _mockRepository.Verify(repo => repo.UpdateOrder(model), Times.Once);
        }
    }
}