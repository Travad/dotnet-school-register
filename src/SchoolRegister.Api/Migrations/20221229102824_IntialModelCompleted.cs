using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolRegister.Api.Migrations
{
    /// <inheritdoc />
    public partial class IntialModelCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationSchools",
                keyColumn: "Id",
                keyValue: new Guid("e6829181-1e6f-40f2-8861-8b9362d12db8"));

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    DateOfConstruction = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LocationSchoolId = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    BirthPlaceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_LocationSchools_BirthPlaceId",
                        column: x => x.BirthPlaceId,
                        principalTable: "LocationSchools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SchoolId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RegistrationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GradeMark = table.Column<double>(type: "REAL", nullable: false),
                    GradeType = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AttendeeId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    { new Guid("6a2fe967-daee-4a20-95ea-70f339dfc17c"), "Via Proviola, 2A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null },
                    { new Guid("745801d7-4678-473c-987d-8cbadfa3bfcb"), "Via Camolo, 13A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "DateOfConstruction", "Description", "Email", "LocationSchoolId", "Name", "PhoneNumber" },
                values: new object[] { new Guid("b198a1ec-b23f-49cc-91f5-4d2a4052331c"), new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.", "info@ittmarconi.it", new Guid("745801d7-4678-473c-987d-8cbadfa3bfcb"), "I.T.T. Marconi", "+390474560781" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "BirthPlaceId", "Email", "FirstName", "LastName", "MiddleName", "PhoneNumber" },
                values: new object[] { new Guid("632dadd2-5fbd-4149-943c-776700697c2a"), new DateTime(2002, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6a2fe967-daee-4a20-95ea-70f339dfc17c"), "john.doe@gmail.com", "John", "Doe", null, "+41123456789" });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "EndDay", "StartDay", "StudentId", "Type" },
                values: new object[] { new Guid("520dccb3-2a51-4022-a85a-215a5ba5fc4c"), new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("632dadd2-5fbd-4149-943c-776700697c2a"), 1 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "EndDate", "Name", "SchoolId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("b262e289-ef17-460d-99fb-5b7712469da1"), "Mobile Development course is a course that teaches the basics of mobile development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Development", new Guid("b198a1ec-b23f-49cc-91f5-4d2a4052331c"), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5bad43d-b512-4d9e-a204-7b91ec9539ed"), "Web Development course is a course that teaches the basics of web development.", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Development", new Guid("b198a1ec-b23f-49cc-91f5-4d2a4052331c"), new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CourseAttendees",
                columns: new[] { "AttendeeId", "CourseId" },
                values: new object[,]
                {
                    { new Guid("520dccb3-2a51-4022-a85a-215a5ba5fc4c"), new Guid("b262e289-ef17-460d-99fb-5b7712469da1") },
                    { new Guid("520dccb3-2a51-4022-a85a-215a5ba5fc4c"), new Guid("b5bad43d-b512-4d9e-a204-7b91ec9539ed") }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AttendeeId", "CourseId", "GradeMark", "GradeType", "RegistrationTime" },
                values: new object[] { new Guid("4835492c-fc96-40f1-83a2-6281427a0349"), new Guid("520dccb3-2a51-4022-a85a-215a5ba5fc4c"), new Guid("b5bad43d-b512-4d9e-a204-7b91ec9539ed"), 8.9000000000000004, 0, new DateTime(2020, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.DeleteData(
                table: "LocationSchools",
                keyColumn: "Id",
                keyValue: new Guid("6a2fe967-daee-4a20-95ea-70f339dfc17c"));

            migrationBuilder.DeleteData(
                table: "LocationSchools",
                keyColumn: "Id",
                keyValue: new Guid("745801d7-4678-473c-987d-8cbadfa3bfcb"));

            migrationBuilder.InsertData(
                table: "LocationSchools",
                columns: new[] { "Id", "Address1", "Address2", "Address3", "Canton", "Cap", "City", "Country", "Province", "Region", "State" },
                values: new object[] { new Guid("e6829181-1e6f-40f2-8861-8b9362d12db8"), "Via Camolo, 13A", null, null, null, "10867", "Isernia", "Italy", "Campobasso", "Molise", null });
        }
    }
}
