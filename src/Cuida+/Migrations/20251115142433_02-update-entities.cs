using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cuida_.Migrations
{
    /// <inheritdoc />
    public partial class _02updateentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampanhaMedico",
                columns: table => new
                {
                    CampanhasId = table.Column<int>(type: "int", nullable: false),
                    MedicosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampanhaMedico", x => new { x.CampanhasId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_CampanhaMedico_Campanhas_CampanhasId",
                        column: x => x.CampanhasId,
                        principalTable: "Campanhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampanhaMedico_Medicos_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CampanhaMedico_MedicosId",
                table: "CampanhaMedico",
                column: "MedicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampanhaMedico");
        }
    }
}
