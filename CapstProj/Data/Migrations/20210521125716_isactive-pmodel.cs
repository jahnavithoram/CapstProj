using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstProj.Data.Migrations
{
    public partial class isactivepmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "ProductModel",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isactive",
                table: "ProductModel");
        }
    }
}
