using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Lookup")]
    public class LookupModel : BaseModel
    {
        public string Value { get; set; }
        public int? SortOrder { get; set; } = null;
        public Guid TypeId { get; set; }
        [ForeignKey(nameof(TypeId))] public virtual LookupTypeModel Type { get; set; }
    }
}