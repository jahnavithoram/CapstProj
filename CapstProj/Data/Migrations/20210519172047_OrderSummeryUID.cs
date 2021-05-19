using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstProj.Data.Migrations
{
    public partial class OrderSummeryUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UID",
                table: "OrderSummeryModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UID",
                table: "OrderSummeryModel");
        }
    }
}
