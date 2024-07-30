using Shared.Dtos.Utilities;

namespace API.Services.Interfaces
{
    public interface IUtilityService
    {
        Task<ManageOrderUtilitiesDto> GetManageOrderUtilities();
        Task<ManageOrderLineUtilitiesDto> GetManageOrderLineUtilities(Guid orderId);
    }
}