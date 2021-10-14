using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class RenameColunsPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tb_Endereco",
                newName: "EnderecoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tb_Cadastro",
                newName: "CadastroId");

            migrationBuilder.AlterColumn<string>(
                name: "Lougradura",
                table: "Tb_Endereco",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Tb_Endereco",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CadastroId",
                table: "Tb_Cadastro",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Lougradura",
                table: "Tb_Endereco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80,
                oldNullable: true);
        }
    }
}
