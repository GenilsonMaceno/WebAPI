using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class AlterParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Endereco_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropColumn(
                name: "CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Endereco_ClienteId",
                table: "Tb_Endereco",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_ClienteId",
                table: "Tb_Endereco",
                column: "ClienteId",
                principalTable: "Tb_Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_ClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Endereco_ClienteId",
                table: "Tb_Endereco");

            migrationBuilder.AddColumn<int>(
                name: "CadastrosClienteId",
                table: "Tb_Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Endereco_CadastrosClienteId",
                table: "Tb_Endereco",
                column: "CadastrosClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_CadastrosClienteId",
                table: "Tb_Endereco",
                column: "CadastrosClienteId",
                principalTable: "Tb_Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
