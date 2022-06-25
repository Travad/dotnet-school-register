using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_school_register.Migrations
{
    public partial class InitialMigrationWithLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    Canton = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cap = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Address1 = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    Canton = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Cap = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Address1 = table.Column<string>(type: "TEXT", nullable: false),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationStudents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LocationSchools",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "Canton", "Cap", "City", "Country", "Province", "Region", "State" },
                values: new object[] { 1, "Via Camolo, 13A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null });

            migrationBuilder.InsertData(
                table: "LocationStudents",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "Canton", "Cap", "City", "Country", "Province", "Region", "State" },
                values: new object[] { 1, "Via Proviola, 2A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSchools");

            migrationBuilder.DropTable(
                name: "LocationStudents");
        }
    }
}
