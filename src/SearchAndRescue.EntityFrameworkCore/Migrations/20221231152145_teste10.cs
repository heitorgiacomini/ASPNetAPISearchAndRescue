using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchAndRescue.Migrations
{
    /// <inheritdoc />
    public partial class teste10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "Business",
                table: "AppOperation");

            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Business",
                table: "AppOperation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                schema: "Business",
                table: "AppOperation",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "Business",
                table: "AppOperation",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "Business",
                table: "AppOperation",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "Business",
                table: "AppOperation",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "Business",
                table: "AppOperation",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Business",
                table: "AppOperation",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "Business",
                table: "AppOperation",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "Business",
                table: "AppOperation",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                schema: "Business",
                table: "AppOperation",
                type: "uuid",
                nullable: true);
        }
    }
}
