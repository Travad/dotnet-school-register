using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_school_register.Migrations
{
    public partial class AddStudentEntityToDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BirthPlaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_LocationStudents_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "LocationStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "BirthPlaceId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2002, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "john.doe@gmail.com", "John", "Doe", null, "+41123456789" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthPlaceId",
                table: "Students",
                column: "BirthPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
