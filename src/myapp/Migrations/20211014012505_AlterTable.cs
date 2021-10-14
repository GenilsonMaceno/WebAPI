using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_Cadastro",
                table: "Tb_Cadastro");

            migrationBuilder.RenameTable(
                name: "Tb_Cadastro",
                newName: "Tb_Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_Cliente",
                table: "Tb_Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_CadastrosClienteId",
                table: "Tb_Endereco",
                column: "CadastrosClienteId",
                principalTable: "Tb_Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cliente_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_Cliente",
                table: "Tb_Cliente");

            migrationBuilder.RenameTable(
                name: "Tb_Cliente",
                newName: "Tb_Cadastro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_Cadastro",
                table: "Tb_Cadastro",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastrosClienteId",
                table: "Tb_Endereco",
                column: "CadastrosClienteId",
                principalTable: "Tb_Cadastro",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
