using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace SearchAndRescue.Migrations
{
    /// <inheritdoc />
    public partial class teste13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Geometry>(
                name: "Geometry",
                schema: "Business",
                table: "AppOperation",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<LineString>(
                name: "Linha",
                schema: "Business",
                table: "AppOperation",
                type: "geometry",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Business",
                table: "AppOperation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Polygon>(
                name: "Poligono",
                schema: "Business",
                table: "AppOperation",
                type: "geometry",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geometry",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "Linha",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "Poligono",
                schema: "Business",
                table: "AppOperation");
        }
    }
}
