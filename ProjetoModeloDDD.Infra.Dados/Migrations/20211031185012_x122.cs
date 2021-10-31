using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoModeloDDD.Infra.Dados.Migrations
{
    public partial class x122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteID1",
                table: "Produto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ClienteID1",
                table: "Produto",
                column: "ClienteID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Cliente_ClienteID1",
                table: "Produto",
                column: "ClienteID1",
                principalTable: "Cliente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Cliente_ClienteID1",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_ClienteID1",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "ClienteID1",
                table: "Produto");
        }
    }
}
