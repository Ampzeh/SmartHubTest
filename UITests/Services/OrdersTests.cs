using Microsoft.VisualStudio.TestTools.UnitTesting;
using UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Dtos;
using UI.Services.Interfaces;
using Moq;
using System.Net.Http.Json;
using System.ComponentModel.Design;

namespace UI.Services.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        private Mock<HttpClient> _mockHttpService;
        private Mock<IHelper> _mockHelper;
        private Orders _orderService;

        [TestInitialize]
        public void Setup()
        {
            _mockHttpService = new Mock<HttpClient>();
            _mockHelper = new Mock<IHelper>();
            _orderService = new Orders(_mockHttpService.Object, _mockHelper.Object);
        }

        [TestMethod]
        public async Task GetOrder_ReturnsOrderDto_WhenOrderExists()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var magicHttpClient = new HttpClient(handlerMock.Object);

            // Arrange
            var orderId = Guid.NewGuid();
            var expectedOrderDto = new OrderDto
            {
                Id = orderId,
                OrderNumber = "123",
                CustomerName = "John Doe",
                OrderDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                TypeId = Guid.NewGuid().ToString(),
                StatusId = Guid.NewGuid().ToString(),
                IsDeleted = false
            };

            _mockHttpService
                .Setup(service => service.GetFromJsonAsync<OrderDto>($"api/order/{orderId}"))
                .ReturnsAsync(expectedOrderDto);

            // Act
            var result = await _orderService.GetOrder(orderId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedOrderDto.Id, result.Id);
            Assert.AreEqual(expectedOrderDto.OrderNumber, result.OrderNumber);
            Assert.AreEqual(expectedOrderDto.CustomerName, result.CustomerName);
            Assert.AreEqual(expectedOrderDto.OrderDate, result.OrderDate);
            Assert.AreEqual(expectedOrderDto.CreatedDate, result.CreatedDate);
            Assert.AreEqual(expectedOrderDto.TypeId, result.TypeId);
            Assert.AreEqual(expectedOrderDto.StatusId, result.StatusId);
            Assert.AreEqual(expectedOrderDto.IsDeleted, result.IsDeleted);
        }
    }
}