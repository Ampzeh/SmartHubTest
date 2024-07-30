using API.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Models;

namespace API.DataAccess
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            SeedLookupTypes();
            SeedOrderTypeLookups();
            SeedOrderStatusLookups();
            SeedProductTypeLookups();
        }

        public DataBuilder<LookupTypeModel> SeedLookupTypes()
        {
            return modelBuilder.Entity<LookupTypeModel>().HasData(
                new LookupTypeModel()
                    {
                        Id = LookupTypes.ORDER_TYPE.Key,
                        Name = LookupTypes.ORDER_TYPE.Value
                    },
                    new LookupTypeModel()
                    {
                        Id = LookupTypes.ORDER_STATUS.Key,
                        Name = LookupTypes.ORDER_STATUS.Value
                    },
                    new LookupTypeModel()
                    {
                        Id = LookupTypes.PRODUCT_TYPE.Key,
                        Name = LookupTypes.PRODUCT_TYPE.Value
                    }
            );
        }

        public DataBuilder<LookupModel> SeedOrderTypeLookups()
        {
            int sortOrder = -1;

            return modelBuilder.Entity<LookupModel>().HasData(
                new LookupModel()
                {
                    Id = OrderTypeLookups.NORMAL.Key,
                    Value = OrderTypeLookups.NORMAL.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_TYPE.Key
                },
                new LookupModel()
                {
                    Id = OrderTypeLookups.STAFF.Key,
                    Value = OrderTypeLookups.STAFF.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_TYPE.Key
                },
                new LookupModel()
                {
                    Id = OrderTypeLookups.MECHANICAL.Key,
                    Value = OrderTypeLookups.MECHANICAL.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_TYPE.Key
                },
                new LookupModel()
                {
                    Id = OrderTypeLookups.PERISHABLE.Key,
                    Value = OrderTypeLookups.PERISHABLE.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_TYPE.Key
                }
            );
        }

        public DataBuilder<LookupModel> SeedOrderStatusLookups()
        {
            int sortOrder = -1;

            return modelBuilder.Entity<LookupModel>().HasData(
                new LookupModel()
                {
                    Id = OrderStatusLookups.NEW.Key,
                    Value = OrderStatusLookups.NEW.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_STATUS.Key
                },
                new LookupModel()
                {
                    Id = OrderStatusLookups.PROCESSING.Key,
                    Value = OrderStatusLookups.PROCESSING.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_STATUS.Key
                },
                new LookupModel()
                {
                    Id = OrderStatusLookups.COMPLETE.Key,
                    Value = OrderStatusLookups.COMPLETE.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.ORDER_STATUS.Key
                }
            );
        }

        public DataBuilder<LookupModel> SeedProductTypeLookups()
        {
            int sortOrder = -1;

            return modelBuilder.Entity<LookupModel>().HasData(
                new LookupModel()
                {
                    Id = ProductTypeLookups.APPAREL.Key,
                    Value = ProductTypeLookups.APPAREL.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.PRODUCT_TYPE.Key
                },
                new LookupModel()
                {
                    Id = ProductTypeLookups.PARTS.Key,
                    Value = ProductTypeLookups.PARTS.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.PRODUCT_TYPE.Key
                },
                new LookupModel()
                {
                    Id = ProductTypeLookups.EQUIPMENT.Key,
                    Value = ProductTypeLookups.EQUIPMENT.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.PRODUCT_TYPE.Key
                },
                new LookupModel()
                {
                    Id = ProductTypeLookups.MOTOR.Key,
                    Value = ProductTypeLookups.MOTOR.Value,
                    SortOrder = sortOrder = sortOrder + 1,
                    TypeId = LookupTypes.PRODUCT_TYPE.Key
                }
            );
        }
    }

}
