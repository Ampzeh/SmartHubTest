using API.Models;

namespace API.Dtos
{
    public class OrderLineDto : BaseDto
    {
        public OrderLineDto() { }

        public OrderLineDto (OrderLineModel model)
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

        public int LineNumber { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal CostPrice { get; set; }
        public Guid OrderId { get; set; }
        public string ProductTypeId { get; set; }

        public string? ProductTypeValue { get; set; }
    }
}
