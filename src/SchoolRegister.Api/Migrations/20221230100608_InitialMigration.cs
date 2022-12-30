using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolRegister.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationSchools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 56, nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Province = table.Column<string>(type: "TEXT", nullable: true),
                    Canton = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 52, nullable: false),
                    Cap = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Address1 = table.Column<string>(type: "TEXT", nullable: false),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address3 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSchools", x => x.Id);
                });

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
                    LocationSchoolId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_LocationSchools_LocationSchoolId",
                        column: x => x.LocationSchoolId,
                        principalTable: "LocationSchools",
                        principalColumn: "Id");
                });

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
                    BirthPlaceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_LocationSchools_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "LocationSchools",
                        principalColumn: "Id");
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
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
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
                    RegistrationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GradeMark = table.Column<double>(type: "REAL", nullable: false),
                    GradeType = table.Column<int>(type: "INTEGER", nullable: false),
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
                table: "LocationSchools",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "Canton", "Cap", "City", "Country", "Province", "Region", "State" },
                values: new object[,]
                {
                    { 1, "Via Camolo, 13A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null },
                    { 2, "Via Proviola, 2A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "DateOfConstruction", "Description", "Email", "LocationSchoolId", "Name", "PhoneNumber" },
                values: new object[] { 1, new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.", "info@ittmarconi.it", 1, "I.T.T. Marconi", "+390474560781" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "BirthPlaceId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { 1, new DateTime(2002, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "john.doe@gmail.com", "John", "Doe", null, "+41123456789" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "EndDay", "StartDay", "StudentId", "Type" },
                values: new object[] { 1, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "EndDate", "Name", "SchoolId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Web Development course is a course that teaches the basics of web development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Development", 1, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Mobile Development course is a course that teaches the basics of mobile development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Development", 1, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CourseAttendees",
                columns: new[] { "AttendeeId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AttendeeId", "CourseId", "GradeMark", "GradeType", "RegistrationTime" },
                values: new object[] { 1, 1, 1, 8.9000000000000004, 0, new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Schools_LocationSchoolId",
                table: "Schools",
                column: "LocationSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BirthPlaceId",
                table: "Students",
                column: "BirthPlaceId");
        }

        /// <inheritdoc />
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

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "LocationSchools");
        }
    }
}
