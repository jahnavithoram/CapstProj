using Microsoft.EntityFrameworkCore.Migrations;

namespace CapstProj.Data.Migrations
{
    public partial class confirmModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmModel",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    UID = table.Column<string>(nullable: true),
                    P_Name = table.Column<string>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    ProductImagePath = table.Column<string>(nullable: true),
                    qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmModel");
        }
    }
}
