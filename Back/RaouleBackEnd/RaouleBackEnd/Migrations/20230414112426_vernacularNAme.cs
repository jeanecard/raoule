using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaouleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class vernacularNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "Oiseaux",
                newName: "Nom");

            migrationBuilder.AddColumn<string>(
                name: "NomVernaculaire",
                table: "Oiseaux",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646741"),
                columns: new[] { "Nom", "NomVernaculaire" },
                values: new object[] { "Merle noir", "Turdus merula" });

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646742"),
                columns: new[] { "Nom", "NomVernaculaire" },
                values: new object[] { "Gris du Gabon", "Psitacus erithacus" });

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646743"),
                columns: new[] { "Nom", "NomVernaculaire" },
                values: new object[] { "Grive musicienne", "Turdus philomelos" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomVernaculaire",
                table: "Oiseaux");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Oiseaux",
                newName: "Caption");

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646741"),
                column: "Caption",
                value: "Turdus merula");

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646742"),
                column: "Caption",
                value: "Psitacus erithacus");

            migrationBuilder.UpdateData(
                table: "Oiseaux",
                keyColumn: "Id",
                keyValue: new Guid("3990c71a-5dff-4b11-8664-256e00646743"),
                column: "Caption",
                value: "Turdus philomelos");
        }
    }
}
