using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookupType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_LookupType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "LookupType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Lookup_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Lookup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Lookup_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_Lookup_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLine_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookupType",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("073a7529-6b8c-40b3-8b2f-117b50eb82be"), false, "OrderType" },
                    { new Guid("baaf686b-0b87-4846-a774-510b2fde7c46"), false, "OrderStatus" },
                    { new Guid("fb991718-8ca8-4b93-a11f-8153980cf49d"), false, "ProductType" }
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "IsDeleted", "SortOrder", "TypeId", "Value" },
                values: new object[,]
                {
                    { new Guid("33e8cd0c-c091-450b-8d99-0d91382a67de"), false, 0, new Guid("073a7529-6b8c-40b3-8b2f-117b50eb82be"), "Normal" },
                    { new Guid("384fd858-8eed-42b3-bdd1-15d9639e088a"), false, 3, new Guid("073a7529-6b8c-40b3-8b2f-117b50eb82be"), "Perishable" },
                    { new Guid("3c1c4c3f-cb7d-479b-9084-abaa1b34208a"), false, 2, new Guid("073a7529-6b8c-40b3-8b2f-117b50eb82be"), "Mechanical" },
                    { new Guid("5ed75422-300d-4a15-8487-a48c1becd664"), false, 1, new Guid("073a7529-6b8c-40b3-8b2f-117b50eb82be"), "Staff" },
                    { new Guid("6b24cbd1-f3ff-4a65-a457-9d09198b2c14"), false, 3, new Guid("fb991718-8ca8-4b93-a11f-8153980cf49d"), "Motor" },
                    { new Guid("6f335a6b-6fef-481a-8fb8-4f85a02685a8"), false, 2, new Guid("fb991718-8ca8-4b93-a11f-8153980cf49d"), "Equipment" },
                    { new Guid("99f5bce5-40d4-41f2-939c-02d66d2d0cfb"), false, 0, new Guid("baaf686b-0b87-4846-a774-510b2fde7c46"), "New" },
                    { new Guid("b37513f7-dba4-4d76-84c3-bdaff996f0b7"), false, 1, new Guid("fb991718-8ca8-4b93-a11f-8153980cf49d"), "Parts" },
                    { new Guid("b91879c8-43be-4ba4-91e8-48088692c812"), false, 0, new Guid("fb991718-8ca8-4b93-a11f-8153980cf49d"), "Apparel" },
                    { new Guid("c2a8f3d8-bec7-43b8-a8b2-4c25580c3a0c"), false, 1, new Guid("baaf686b-0b87-4846-a774-510b2fde7c46"), "Processing" },
                    { new Guid("e7cd4913-f470-4071-8f06-cdd877063b28"), false, 2, new Guid("baaf686b-0b87-4846-a774-510b2fde7c46"), "Complete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_TypeId",
                table: "Lookup",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TypeId",
                table: "Order",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_ProductTypeId",
                table: "OrderLine",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "LookupType");
        }
    }
}
