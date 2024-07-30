namespace UI.Dtos
{
    public class LookupDto
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public int? SortOrder { get; set; } = null;
        public Guid TypeId { get; set; }
    }
}
