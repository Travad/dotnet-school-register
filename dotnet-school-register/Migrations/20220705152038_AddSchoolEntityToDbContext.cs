using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_school_register.Migrations
{
    public partial class AddSchoolEntityToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    DateOfConstruction = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LocationSchoolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_LocationSchools_LocationSchoolId",
                        column: x => x.LocationSchoolId,
                        principalTable: "LocationSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "DateOfConstruction", "Description", "Email", "LocationSchoolId", "Name", "PhoneNumber" },
                values: new object[] { 1, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.", "", 1, "I.T.T. Marconi", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Schools_LocationSchoolId",
                table: "Schools",
                column: "LocationSchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
