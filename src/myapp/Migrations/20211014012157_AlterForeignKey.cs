using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class AlterForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastroId",
                table: "Tb_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Endereco_CadastroId",
                table: "Tb_Endereco");

            migrationBuilder.RenameColumn(
                name: "CadastroId",
                table: "Tb_Endereco",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "CadastroId",
                table: "Tb_Cadastro",
                newName: "ClienteId");

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
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastrosClienteId",
                table: "Tb_Endereco",
                column: "CadastrosClienteId",
                principalTable: "Tb_Cadastro",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Endereco_CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.DropColumn(
                name: "CadastrosClienteId",
                table: "Tb_Endereco");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Tb_Endereco",
                newName: "CadastroId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Tb_Cadastro",
                newName: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Endereco_CadastroId",
                table: "Tb_Endereco",
                column: "CadastroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastroId",
                table: "Tb_Endereco",
                column: "CadastroId",
                principalTable: "Tb_Cadastro",
                principalColumn: "CadastroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
