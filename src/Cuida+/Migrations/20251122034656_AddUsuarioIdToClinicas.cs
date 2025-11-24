using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuida_.Migrations
{
    public partial class AddUsuarioIdToClinicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remover estes DROP COLUMN porque estava quebrando
            // migrationBuilder.DropColumn("CNPJ", "Clinicas");
            // migrationBuilder.DropColumn("NomeFantasia", "Clinicas");

            // Se a coluna já é "Cnpj", renomear para "CNPJ"
            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Clinicas",
                newName: "CNPJ");

            // Ajustar o tipo
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Clinicas",
                type: "varchar(255)",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            // Criar índice único
            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_CNPJ",
                table: "Clinicas",
                column: "CNPJ",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clinicas_CNPJ",
                table: "Clinicas");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "Clinicas",
                newName: "Cnpj");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Clinicas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
