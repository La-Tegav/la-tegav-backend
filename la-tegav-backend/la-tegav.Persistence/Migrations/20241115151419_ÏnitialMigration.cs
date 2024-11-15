using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_tegav.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ÏnitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "[NVARCHAR](255)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "[DATE]", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "[DATE]", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "[NVARCHAR](25)", nullable: false),
                    Description = table.Column<string>(type: "[NVARCHAR](255)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(type: "[BIT]", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "[NVARCHAR](255)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnityPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_OrderItem_TB_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TB_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_OrderItem_OrderId",
                table: "TB_OrderItem",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_OrderItem");

            migrationBuilder.DropTable(
                name: "TB_Product");

            migrationBuilder.DropTable(
                name: "TB_Order");
        }
    }
}
