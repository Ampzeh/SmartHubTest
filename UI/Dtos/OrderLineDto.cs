using System.ComponentModel.DataAnnotations;

namespace UI.Dtos
{
    public class OrderLineDto : BaseDto
    {
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

        public string ProductTypeValue { get; set; }
    }
}
