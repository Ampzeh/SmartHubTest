using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class OrderLineDto : BaseDto
    {
        public OrderLineDto() { }

        public OrderLineDto(OrderLineModel model)
        {
            Id = model.Id;
            LineNumber = model.LineNumber;
            ProductCode = model.ProductCode;
            Quantity = model.Quantity;
            SalesPrice = model.SalesPrice;
            CostPrice = model.CostPrice;
            OrderId = model.OrderId;
            ProductTypeId = model.ProductTypeId.ToString();

            ProductTypeValue = model.ProductType?.Value;
        }

        [Required]
        public int LineNumber { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? SalesPrice { get; set; }
        [Required]
        public decimal? CostPrice { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public string ProductTypeId { get; set; }

        public string? ProductTypeValue { get; set; }
    }
}
