using Shared.Dtos;

namespace Shared.Dtos.Utilities
{
    public class ManageOrderUtilitiesDto
    {
        public List<LookupDto> OrderTypes { get; set; }
        public List<LookupDto> OrderStatuses { get; set; }
    }
}
