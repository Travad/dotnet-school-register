using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_school_register.Migrations
{
    public partial class FinalTemplateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendees_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchoolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAttendees",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAttendees", x => new { x.CourseId, x.AttendeeId });
                    table.ForeignKey(
                        name: "FK_CourseAttendees_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAttendees_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    GradeMark = table.Column<double>(type: "REAL", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: true),
                    AttendeeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_CourseAttendees_CourseId_AttendeeId",
                        columns: x => new { x.CourseId, x.AttendeeId },
                        principalTable: "CourseAttendees",
                        principalColumns: new[] { "CourseId", "AttendeeId" });
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "EndDay", "StartDay", "StudentId" },
                values: new object[] { 1, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "EndDate", "Name", "SchoolId", "StartDate" },
                values: new object[] { 1, "Web Development course is a course that teaches the basics of web development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Development", 1, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "EndDate", "Name", "SchoolId", "StartDate" },
                values: new object[] { 2, "Mobile Development course is a course that teaches the basics of mobile development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Development", 1, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CourseAttendees",
                columns: new[] { "AttendeeId", "CourseId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CourseAttendees",
                columns: new[] { "AttendeeId", "CourseId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AttendeeId", "CourseId", "GradeMark", "RegistrationTime" },
                values: new object[] { 1, 1, 1, 8.9000000000000004, new DateTimeOffset(new DateTime(2020, 10, 3, 10, 22, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_StudentId",
                table: "Attendees",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttendees_AttendeeId",
                table: "CourseAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId_AttendeeId",
                table: "Grades",
                columns: new[] { "CourseId", "AttendeeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "CourseAttendees");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
