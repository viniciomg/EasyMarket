using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyMarket.Infra.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Produtos",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Produtos");
        }
    }
}
