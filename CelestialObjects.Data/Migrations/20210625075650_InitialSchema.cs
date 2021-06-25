using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelestialObjects.Data.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CelestialObjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverySourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySourceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscoverySources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    StateOwner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscoverySources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscoverySources_DiscoverySourceTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "DiscoverySourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CelestialObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    EquatorialDiameter = table.Column<double>(type: "float", nullable: false),
                    SurfaceTemperature = table.Column<double>(type: "float", nullable: false),
                    DiscoveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscoverySourceId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelestialObjects_CelestialObjectTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CelestialObjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CelestialObjects_DiscoverySources_DiscoverySourceId",
                        column: x => x.DiscoverySourceId,
                        principalTable: "DiscoverySources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CelestialObjectTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Planet", "Planet" },
                    { 2, "Star", "Star" },
                    { 3, "Black Hole", "BlackHole" }
                });

            migrationBuilder.InsertData(
                table: "DiscoverySourceTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "Ground Telescopte", "GroundTelescope" },
                    { 1, "Space Telescope", "SpaceTelescope" },
                    { 3, "Other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "DiscoverySources",
                columns: new[] { "Id", "EstablishmentDate", "Name", "StateOwner", "TypeId" },
                values: new object[] { 2, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arecibo Observatory", "Puerto Rico", 2 });

            migrationBuilder.InsertData(
                table: "DiscoverySources",
                columns: new[] { "Id", "EstablishmentDate", "Name", "StateOwner", "TypeId" },
                values: new object[] { 1, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hubble Space Telescope", "USA", 1 });

            migrationBuilder.InsertData(
                table: "CelestialObjects",
                columns: new[] { "Id", "DiscoveryDate", "DiscoverySourceId", "EquatorialDiameter", "Mass", "Name", "SurfaceTemperature", "TypeId" },
                values: new object[] { 3, new DateTime(2010, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 184502000.0, 3.6499999999999997E+29, "V538 Carinae", 4800.0, 2 });

            migrationBuilder.InsertData(
                table: "CelestialObjects",
                columns: new[] { "Id", "DiscoveryDate", "DiscoverySourceId", "EquatorialDiameter", "Mass", "Name", "SurfaceTemperature", "TypeId" },
                values: new object[] { 1, new DateTime(2018, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 12756200.0, 5.9723699999999995E+24, "Kepler-37b", 5800.0, 1 });

            migrationBuilder.InsertData(
                table: "CelestialObjects",
                columns: new[] { "Id", "DiscoveryDate", "DiscoverySourceId", "EquatorialDiameter", "Mass", "Name", "SurfaceTemperature", "TypeId" },
                values: new object[] { 2, new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4280000.0, 4.2000000000000002E+40, "X1 NGC 4889", 2000.0, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObjects_DiscoverySourceId",
                table: "CelestialObjects",
                column: "DiscoverySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_CelestialObjects_TypeId",
                table: "CelestialObjects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscoverySources_TypeId",
                table: "DiscoverySources",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CelestialObjects");

            migrationBuilder.DropTable(
                name: "CelestialObjectTypes");

            migrationBuilder.DropTable(
                name: "DiscoverySources");

            migrationBuilder.DropTable(
                name: "DiscoverySourceTypes");
        }
    }
}
