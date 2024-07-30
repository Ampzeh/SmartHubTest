using Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public class OrderDto : BaseDto
    {
        public OrderDto() { }

        public OrderDto(OrderModel model)
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

        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string? StatusId { get; set; }
        [Required]
        public string? TypeId { get; set; }

        public string? TypeValue { get; set; }
        public string? StatusValue { get; set; }
    }
}
