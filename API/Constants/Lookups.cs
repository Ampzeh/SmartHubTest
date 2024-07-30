namespace API.Constants
{
    public static class OrderTypeLookups
    {
        public static readonly KeyValuePair<Guid, string> NORMAL = new(Guid.Parse("33e8cd0c-c091-450b-8d99-0d91382a67de"), "Normal");
        public static readonly KeyValuePair<Guid, string> STAFF = new(Guid.Parse("5ed75422-300d-4a15-8487-a48c1becd664"), "Staff");
        public static readonly KeyValuePair<Guid, string> MECHANICAL = new(Guid.Parse("3c1c4c3f-cb7d-479b-9084-abaa1b34208a"), "Mechanical");
        public static readonly KeyValuePair<Guid, string> PERISHABLE = new(Guid.Parse("384fd858-8eed-42b3-bdd1-15d9639e088a"), "Perishable");
    }
    public static class OrderStatusLookups
    {
        public static readonly KeyValuePair<Guid, string> NEW = new(Guid.Parse("99f5bce5-40d4-41f2-939c-02d66d2d0cfb"), "New");
        public static readonly KeyValuePair<Guid, string> PROCESSING = new(Guid.Parse("c2a8f3d8-bec7-43b8-a8b2-4c25580c3a0c"), "Processing");
        public static readonly KeyValuePair<Guid, string> COMPLETE = new(Guid.Parse("e7cd4913-f470-4071-8f06-cdd877063b28"), "Complete");
    }
    public static class ProductTypeLookups
    {
        public static readonly KeyValuePair<Guid, string> APPAREL = new(Guid.Parse("b91879c8-43be-4ba4-91e8-48088692c812"), "Apparel");
        public static readonly KeyValuePair<Guid, string> PARTS = new(Guid.Parse("b37513f7-dba4-4d76-84c3-bdaff996f0b7"), "Parts");
        public static readonly KeyValuePair<Guid, string> EQUIPMENT = new(Guid.Parse("6f335a6b-6fef-481a-8fb8-4f85a02685a8"), "Equipment");
        public static readonly KeyValuePair<Guid, string> MOTOR = new(Guid.Parse("6b24cbd1-f3ff-4a65-a457-9d09198b2c14"), "Motor");
    }
}
