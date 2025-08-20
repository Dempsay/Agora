using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class TiposInscripcionesCapacitaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposInscripcionesCapacitacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    TipoInscripcionId = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInscripcionesCapacitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitacion_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposInscripcionesCapacitacion_TipoInscripciones_TipoInscrip~",
                        column: x => x.TipoInscripcionId,
                        principalTable: "TipoInscripciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TiposInscripcionesCapacitacion",
                columns: new[] { "Id", "CapacitacionId", "Costo", "IsDeleted", "TipoInscripcionId" },
                values: new object[,]
                {
                    { 1, 1, 10000m, false, 1 },
                    { 2, 1, 8000m, false, 2 },
                    { 3, 1, 5000m, false, 3 },
                    { 4, 1, 3000m, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitacion_CapacitacionId",
                table: "TiposInscripcionesCapacitacion",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposInscripcionesCapacitacion_TipoInscripcionId",
                table: "TiposInscripcionesCapacitacion",
                column: "TipoInscripcionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposInscripcionesCapacitacion");
        }
    }
}
