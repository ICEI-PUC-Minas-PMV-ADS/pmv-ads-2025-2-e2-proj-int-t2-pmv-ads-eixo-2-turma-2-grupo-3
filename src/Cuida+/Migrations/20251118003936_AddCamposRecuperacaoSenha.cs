using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuida_.Migrations
{
    public partial class AddCamposRecuperacaoSenha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenRecuperacao",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpiracao",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenRecuperacao",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TokenExpiracao",
                table: "Usuarios");
        }
    }
}
