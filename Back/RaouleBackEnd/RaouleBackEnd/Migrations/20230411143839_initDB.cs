using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaouleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LieuxObservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LieuxObservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oiseaux",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oiseaux", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypePaysage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LieuObservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePaysage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypePaysage_LieuxObservations_LieuObservationId",
                        column: x => x.LieuObservationId,
                        principalTable: "LieuxObservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OiseauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LieuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_LieuxObservations_LieuId",
                        column: x => x.LieuId,
                        principalTable: "LieuxObservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observations_Oiseaux_OiseauId",
                        column: x => x.OiseauId,
                        principalTable: "Oiseaux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Oiseaux",
                columns: new[] { "Id", "Caption" },
                values: new object[,]
                {
                    { new Guid("3990c71a-5dff-4b11-8664-256e00646741"), "Turdus merula" },
                    { new Guid("3990c71a-5dff-4b11-8664-256e00646742"), "Psitacus erithacus gris" },
                    { new Guid("3990c71a-5dff-4b11-8664-256e00646743"), "Turdus philomelos" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Observations_LieuId",
                table: "Observations",
                column: "LieuId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_OiseauId",
                table: "Observations",
                column: "OiseauId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePaysage_LieuObservationId",
                table: "TypePaysage",
                column: "LieuObservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "TypePaysage");

            migrationBuilder.DropTable(
                name: "Oiseaux");

            migrationBuilder.DropTable(
                name: "LieuxObservations");
        }
    }
}
