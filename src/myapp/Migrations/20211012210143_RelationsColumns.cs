using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class RelationsColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
