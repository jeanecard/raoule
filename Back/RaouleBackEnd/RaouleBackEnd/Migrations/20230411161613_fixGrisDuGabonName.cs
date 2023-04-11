using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaouleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class fixGrisDuGabonName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646742"),
                column: "Caption",
                value: "Psitacus erithacus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646742"),
                column: "Caption",
                value: "Psitacus erithacus gris");
        }
    }
}
