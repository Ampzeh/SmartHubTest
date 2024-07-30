namespace API.Constants
{
    public static class LookupTypes
    {
        public static readonly KeyValuePair<Guid, string> ORDER_TYPE = new (Guid.Parse("073a7529-6b8c-40b3-8b2f-117b50eb82be"), "OrderType");
        public static readonly KeyValuePair<Guid, string> ORDER_STATUS = new (Guid.Parse("baaf686b-0b87-4846-a774-510b2fde7c46"), "OrderStatus");
        public static readonly KeyValuePair<Guid, string> PRODUCT_TYPE = new (Guid.Parse("fb991718-8ca8-4b93-a11f-8153980cf49d"), "ProductType");
    }
}
