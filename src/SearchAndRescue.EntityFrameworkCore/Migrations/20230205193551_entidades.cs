using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SearchAndRescue.Migrations
{
    /// <inheritdoc />
    public partial class entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppOperation",
                schema: "Business");

            migrationBuilder.CreateTable(
                name: "AppCountryBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCountryBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppGeoFunctionsBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PointAsGeometry = table.Column<Point>(type: "geometry (PointZ, 4326)", nullable: true),
                    PointAsGeography = table.Column<Point>(type: "geography(POINT,4326)", nullable: true),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    Poligono = table.Column<Polygon>(type: "geometry", nullable: true),
                    Linha = table.Column<LineString>(type: "geometry", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGeoFunctionsBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPathSearchOperationBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeographyLineString = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Precisao = table.Column<int>(type: "integer", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPathSearchOperationBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPathSearchOperationBusiness_AbpUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRaceBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRaceBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationStatusBusiness",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationStatusBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SexBusiness",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SexBusiness", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppStateBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CountryBusinessId = table.Column<long>(type: "bigint", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppStateBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppStateBusiness_AppCountryBusiness_CountryBusinessId",
                        column: x => x.CountryBusinessId,
                        principalSchema: "Business",
                        principalTable: "AppCountryBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppOperationBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    PointOfInterest = table.Column<Point>(type: "geometry (PointZ, 4326)", nullable: true),
                    RadiusOfInterestInKm = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    OperationStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperationBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppOperationBusiness_OperationStatusBusiness_OperationStatu~",
                        column: x => x.OperationStatusId,
                        principalTable: "OperationStatusBusiness",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppMissingPersonBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastSeenPoint = table.Column<Point>(type: "geography(Point,4326)", nullable: true),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    RaceId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(210)", maxLength: 210, nullable: true),
                    SexId = table.Column<long>(type: "bigint", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    EyeColor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    HairColor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Clothes = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMissingPersonBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppMissingPersonBusiness_AppRaceBusiness_RaceId",
                        column: x => x.RaceId,
                        principalSchema: "Business",
                        principalTable: "AppRaceBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppMissingPersonBusiness_SexBusiness_SexId",
                        column: x => x.SexId,
                        principalTable: "SexBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppCityBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCityBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppCityBusiness_AppStateBusiness_StateId",
                        column: x => x.StateId,
                        principalSchema: "Business",
                        principalTable: "AppStateBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppAdressBusiness",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostalCode = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Street = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAdressBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAdressBusiness_AppCityBusiness_CityId",
                        column: x => x.CityId,
                        principalSchema: "Business",
                        principalTable: "AppCityBusiness",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAdressBusiness_CityId",
                schema: "Business",
                table: "AppAdressBusiness",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCityBusiness_StateId",
                schema: "Business",
                table: "AppCityBusiness",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMissingPersonBusiness_RaceId",
                schema: "Business",
                table: "AppMissingPersonBusiness",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_AppMissingPersonBusiness_SexId",
                schema: "Business",
                table: "AppMissingPersonBusiness",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_AppOperationBusiness_OperationStatusId",
                schema: "Business",
                table: "AppOperationBusiness",
                column: "OperationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPathSearchOperationBusiness_IdentityUserId",
                schema: "Business",
                table: "AppPathSearchOperationBusiness",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppStateBusiness_CountryBusinessId",
                schema: "Business",
                table: "AppStateBusiness",
                column: "CountryBusinessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppAdressBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppGeoFunctionsBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppMissingPersonBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppOperationBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppPathSearchOperationBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppCityBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppRaceBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "SexBusiness");

            migrationBuilder.DropTable(
                name: "OperationStatusBusiness");

            migrationBuilder.DropTable(
                name: "AppStateBusiness",
                schema: "Business");

            migrationBuilder.DropTable(
                name: "AppCountryBusiness",
                schema: "Business");

            migrationBuilder.CreateTable(
                name: "AppOperation",
                schema: "Business",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    Geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    Linha = table.Column<LineString>(type: "geometry", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PointAsGeography = table.Column<Point>(type: "geography(POINT,4326)", nullable: true),
                    PointAsGeometry = table.Column<Point>(type: "geometry (PointZ, 4326)", nullable: true),
                    Poligono = table.Column<Polygon>(type: "geometry", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOperation", x => x.Id);
                });
        }
    }
}
