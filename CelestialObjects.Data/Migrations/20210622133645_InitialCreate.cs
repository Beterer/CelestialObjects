using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelestialObjects.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscoverySources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StateOwner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CelestialObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquatorialDiameter = table.Column<double>(type: "float", nullable: false),
                    SurfaceTemperature = table.Column<double>(type: "float", nullable: false),
                    DiscoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscoverySourceId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialObjects_DiscoverySources_DiscoverySourceId",
                        column: x => x.DiscoverySourceId,
                        principalTable: "DiscoverySources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObjects_DiscoverySourceId",
                table: "CelestialObjects",
                column: "DiscoverySourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialObjects");

            migrationBuilder.DropTable(
                name: "DiscoverySources");
        }
    }
}
