using System.ComponentModel.DataAnnotations;

namespace UI.Dtos
{
    public class OrderDto : BaseDto
    {
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string? StatusId { get; set; }
        [Required]
        public string? TypeId { get; set; }

        public string? TypeValue { get; set; }
        public string? StatusValue { get; set; }
    }
}
