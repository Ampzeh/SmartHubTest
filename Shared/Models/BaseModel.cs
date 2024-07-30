using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}