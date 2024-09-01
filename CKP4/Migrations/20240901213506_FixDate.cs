using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CKP4.Migrations
{
    /// <inheritdoc />
    public partial class FixDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascimento",
                table: "TB_CP4_PACIENTE",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.UpdateData(
                table: "TB_CP4_PACIENTE",
                keyColumn: "Id",
                keyValue: 1,
                column: "DtNascimento",
                value: new DateTime(2024, 9, 1, 18, 35, 5, 745, DateTimeKind.Local).AddTicks(3914));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNascimento",
                table: "TB_CP4_PACIENTE",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.UpdateData(
                table: "TB_CP4_PACIENTE",
                keyColumn: "Id",
                keyValue: 1,
                column: "DtNascimento",
                value: new DateTime(2024, 9, 1, 18, 26, 16, 183, DateTimeKind.Local).AddTicks(2173));
        }
    }
}
