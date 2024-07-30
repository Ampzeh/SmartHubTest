using API.Models;

namespace API.Dtos
{
    public class LookupDto
    {
        public LookupDto() { }

        public LookupDto (LookupModel model)
        {
            Id = model.Id.ToString();
            Value = model.Value;
            SortOrder = model.SortOrder;
            TypeId = model.TypeId;
        }

        public string Value { get; set; }
        public int? SortOrder { get; set; } = null;
        public Guid TypeId { get; set; }

        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
