using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstProj.Data.Migrations
{
    public partial class unitcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "unitCost",
                table: "CartModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unitCost",
                table: "CartModel");
        }
    }
}
