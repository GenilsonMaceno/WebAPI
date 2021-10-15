using Microsoft.EntityFrameworkCore.Migrations;

namespace webapi.Migrations
{
    public partial class AddColunsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Tb_Endereco",
                type: "varchar(40)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Tb_Endereco",
                type: "varchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Tb_Cliente",
                type: "char(11)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Tb_Endereco");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Tb_Endereco");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Tb_Cliente");
        }
    }
}
