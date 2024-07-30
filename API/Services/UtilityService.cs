using API.Constants;
using API.DataAccess;
using API.Dtos;
using API.Dtos.Utilities;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly MainContext _context;

        public UtilityService(MainContext context)
        {
            _context = context;
        }

        public async Task<ManageOrderUtilitiesDto> GetManageOrderUtilities()
        {
            return new ManageOrderUtilitiesDto
            {
                OrderTypes = await _context.Lookup
                .Where(_ => !_.IsDeleted && _.TypeId == LookupTypes.ORDER_TYPE.Key)
                .OrderBy(_ => _.SortOrder)
                .Select(_ => new LookupDto(_))
                .ToListAsync(),

                OrderStatuses = await _context.Lookup
                .Where(_ => !_.IsDeleted && _.TypeId == LookupTypes.ORDER_STATUS.Key)
                .OrderBy(_ => _.SortOrder)
                .Select(_ => new LookupDto(_))
                .ToListAsync()
            };
        }

        public async Task<ManageOrderLineUtilitiesDto> GetManageOrderLineUtilities(Guid orderId)
        {
            var previousOrderLine = await _context.OrderLine
                .Where(_ => !_.IsDeleted &&_.OrderId == orderId)
                .OrderByDescending(_ => _.LineNumber).FirstOrDefaultAsync();

            return new ManageOrderLineUtilitiesDto
            {
                ProductTypes = await _context.Lookup
                .Where(_ => !_.IsDeleted && _.TypeId == LookupTypes.PRODUCT_TYPE.Key)
                .OrderBy(_ => _.SortOrder)
                .Select(_ => new LookupDto(_))
                .ToListAsync(),

                NextLineNumber = previousOrderLine?.LineNumber + 1 ?? 1
            };
        }
    }
}
