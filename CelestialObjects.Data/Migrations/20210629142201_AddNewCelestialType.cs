using Microsoft.EntityFrameworkCore.Migrations;

namespace CelestialObjects.Data.Migrations
{
    public partial class AddNewCelestialType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CelestialObjectTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "Undetermined", "Undetermined" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CelestialObjectTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
