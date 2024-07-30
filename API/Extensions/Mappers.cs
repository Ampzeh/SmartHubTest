using Shared.Dtos;
using Shared.Models;

namespace API.Extensions
{
    public static class Mappers
    {
        public static OrderModel MapToModel(this OrderDto dto)
        {
            if (dto == null)
                return new OrderModel();

            return new OrderModel()
            {
                OrderNumber = dto.OrderNumber,
                CustomerName = dto.CustomerName,
                OrderDate = (DateTime)dto.OrderDate,
                CreatedDate = dto.CreatedDate,
                TypeId = dto.TypeId != null ? Guid.Parse(dto.TypeId) : null,
                StatusId = dto.StatusId != null ? Guid.Parse(dto.StatusId) : null
            };
        }

        public static OrderModel MapToModel(this OrderDto dto, OrderModel model)
        {
            model.OrderNumber = dto.OrderNumber;
            model.CustomerName = dto.CustomerName;
            model.OrderDate = (DateTime)dto.OrderDate;
            model.CreatedDate = dto.CreatedDate;
            model.TypeId = dto.TypeId != null ? Guid.Parse(dto.TypeId) : null;
            model.StatusId = dto.StatusId != null ? Guid.Parse(dto.StatusId) : null;

            return model;
        }
        public static OrderLineModel MapToModel(this OrderLineDto dto)
        {
            if (dto == null)
                return new OrderLineModel();

            return new OrderLineModel()
            {
                LineNumber = dto.LineNumber,
                ProductCode = dto.ProductCode,
                Quantity = (int)dto.Quantity,
                SalesPrice = (decimal)dto.SalesPrice,
                CostPrice = (decimal)dto.CostPrice,
                OrderId = dto.OrderId,
                ProductTypeId = dto.ProductTypeId != null ? Guid.Parse(dto.ProductTypeId) : null
            };
        }

        public static OrderLineModel MapToModel(this OrderLineDto dto, OrderLineModel model)
        {
            model.LineNumber = dto.LineNumber;
            model.ProductCode = dto.ProductCode;
            model.Quantity = (int)dto.Quantity;
            model.SalesPrice = (decimal)dto.SalesPrice;
            model.CostPrice = (decimal)dto.CostPrice;
            model.OrderId = dto.OrderId;
            model.ProductTypeId = dto.ProductTypeId != null ? Guid.Parse(dto.ProductTypeId) : null;

            return model;
        }
    }
}
