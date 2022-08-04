using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRegister.API.Migrations
{
    public partial class NewGradeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationTime",
                value: new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationTime",
                value: new DateTimeOffset(new DateTime(2020, 10, 3, 10, 22, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
