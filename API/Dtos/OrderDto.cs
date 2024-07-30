using API.Models;

namespace API.Dtos
{
    public class OrderDto : BaseDto
    {
        public OrderDto() { }

        public OrderDto (OrderModel model)
        {
            Id = model.Id;
            OrderNumber = model.OrderNumber;
            CustomerName = model.CustomerName;
            OrderDate = model.OrderDate;
            CreatedDate = model.CreatedDate;
            StatusId = model.StatusId.ToString();
            TypeId = model.TypeId.ToString();

            TypeValue = model.Type?.Value;
            StatusValue = model.Status?.Value;
        }

        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StatusId { get; set; }
        public string TypeId { get; set; }

        public string? TypeValue { get; set; }
        public string? StatusValue { get; set; }
    }
}
