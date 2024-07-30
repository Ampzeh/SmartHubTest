using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    [Table("OrderLine")]
    public class OrderLineModel : BaseModel
    {
        public int LineNumber { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal CostPrice { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))] public virtual OrderModel Order { get; set; }
        public Guid? ProductTypeId { get; set; }
        [ForeignKey(nameof(ProductTypeId))] public virtual LookupModel ProductType { get; set; }
    }
}