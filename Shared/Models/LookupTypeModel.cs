using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    [Table("LookupType")]
    public class LookupTypeModel : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<LookupModel> Lookups { get; set; }
    }
}