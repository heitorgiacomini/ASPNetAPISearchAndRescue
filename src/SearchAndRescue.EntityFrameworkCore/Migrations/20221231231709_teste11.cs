using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchAndRescue.Migrations
{
    /// <inheritdoc />
    public partial class teste11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Business",
                table: "AppOperation",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                schema: "Business",
                table: "AppOperation",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                schema: "Business",
                table: "AppOperation");
        }
    }
}
