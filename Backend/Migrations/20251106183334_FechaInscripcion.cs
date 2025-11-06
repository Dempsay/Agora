using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FechaInscripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInscripcion",
                table: "Inscripciones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5858));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Inscripciones",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaInscripcion",
                value: new DateTime(2025, 11, 6, 15, 33, 31, 798, DateTimeKind.Local).AddTicks(5883));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaInscripcion",
                table: "Inscripciones");
        }
    }
}
