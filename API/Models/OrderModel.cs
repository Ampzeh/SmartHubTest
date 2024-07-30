using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Order")]
    public class OrderModel : BaseModel
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? TypeId { get; set; }
        [ForeignKey(nameof(TypeId))] public virtual LookupModel Type { get; set; }
        public Guid? StatusId { get; set; }
        [ForeignKey(nameof(StatusId))] public virtual LookupModel Status { get; set; }
    }
}
