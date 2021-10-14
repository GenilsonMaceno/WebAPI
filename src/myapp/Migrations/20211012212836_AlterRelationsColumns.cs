using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class AlterRelationsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Cadastro_Tb_Endereco_EnderecoId",
                table: "Tb_Cadastro");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Cadastro_EnderecoId",
                table: "Tb_Cadastro");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Tb_Cadastro");

            migrationBuilder.AddColumn<int>(
                name: "CadastroId",
                table: "Tb_Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_Endereco_Tb_Cadastro_CadastroId",
                table: "Tb_Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Tb_Endereco_CadastroId",
                table: "Tb_Endereco");

            migrationBuilder.DropColumn(
                name: "CadastroId",
                table: "Tb_Endereco");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Tb_Cadastro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Cadastro_EnderecoId",
                table: "Tb_Cadastro",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_Cadastro_Tb_Endereco_EnderecoId",
                table: "Tb_Cadastro",
                column: "EnderecoId",
                principalTable: "Tb_Endereco",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
