using Microsoft.EntityFrameworkCore.Migrations;

namespace Bd.Api.Migrations
{
    public partial class addColumnToOrderItemMgr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalQuantityPrice",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuantityPrice",
                table: "OrderItems");
        }
    }
}
