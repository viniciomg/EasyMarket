using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EasyMarket.Infra.Migrations
{
    public partial class entradas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Produtos_produtosId",
                table: "Entradas");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_produtosId",
                table: "Entradas");

            migrationBuilder.RenameColumn(
                name: "produtosId",
                table: "Entradas",
                newName: "fornecedorId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fornecedor",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ChaveDeAcesso",
                table: "Entradas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ValorTotal",
                table: "Entradas",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "EntradaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntradasId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    PrecoCompra = table.Column<float>(type: "real", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaItems_Entradas_EntradasId",
                        column: x => x.EntradasId,
                        principalTable: "Entradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradaItems_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaItems_EntradasId",
                table: "EntradaItems",
                column: "EntradasId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaItems_ProdutoId",
                table: "EntradaItems",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaItems");

            migrationBuilder.DropColumn(
                name: "ChaveDeAcesso",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Entradas");

            migrationBuilder.RenameColumn(
                name: "fornecedorId",
                table: "Entradas",
                newName: "produtosId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fornecedor",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'1', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_produtosId",
                table: "Entradas",
                column: "produtosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Produtos_produtosId",
                table: "Entradas",
                column: "produtosId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
