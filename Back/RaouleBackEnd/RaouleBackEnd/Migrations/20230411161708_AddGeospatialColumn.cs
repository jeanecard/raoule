using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace RaouleBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddGeospatialColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<GeometryCollection>(
                name: "Localisations",
                table: "LieuxObservations",
                type: "geography",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localisations",
                table: "LieuxObservations");
        }
    }
}
