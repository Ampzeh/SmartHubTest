using UI.Dtos.Utilities;

namespace UI.Services.Interfaces
{
    public interface IUtilityService
    {
        Task<ManageOrderUtilitiesDto> GetManageOrderUtilities();
        Task<ManageOrderLineUtilitiesDto> GetManageOrderLineUtilities(Guid orderId);
    }
}