﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolRegister.API.DbContexts;

#nullable disable

namespace SchoolRegister.API.Migrations
{
    [DbContext(typeof(SchoolRegisterDbContext))]
    [Migration("20220713121434_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("SchoolRegister.API.Entities.Attendees.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDay = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDay = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.CourseAttendees.CourseAttendee", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttendeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CourseId", "AttendeeId");

                    b.HasIndex("AttendeeId");

                    b.ToTable("CourseAttendees");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            AttendeeId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            AttendeeId = 1
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Courses.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("SchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Web Development course is a course that teaches the basics of web development.",
                            EndDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Web Development",
                            SchoolId = 1,
                            StartDate = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Mobile Development course is a course that teaches the basics of mobile development.",
                            EndDate = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mobile Development",
                            SchoolId = 1,
                            StartDate = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Grades.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AttendeeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GradeMark")
                        .HasColumnType("REAL");

                    b.Property<DateTimeOffset>("RegistrationTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CourseId", "AttendeeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttendeeId = 1,
                            CourseId = 1,
                            GradeMark = 8.9000000000000004,
                            RegistrationTime = new DateTimeOffset(new DateTime(2020, 10, 3, 10, 22, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Locations.LocationSchool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Canton")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cap")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LocationSchools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "Via Camolo, 13A",
                            Cap = "10867",
                            City = "Isernia",
                            Country = "Italy",
                            Province = "Campobasso",
                            Region = "Molise"
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Locations.LocationStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Canton")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cap")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Province")
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LocationStudents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address1 = "Via Proviola, 2A",
                            Cap = "10867",
                            City = "Isernia",
                            Country = "Italy",
                            Province = "Campobasso",
                            Region = "Molise"
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Schools.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfConstruction")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationSchoolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationSchoolId");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfConstruction = new DateTime(1985, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.",
                            Email = "",
                            LocationSchoolId = 1,
                            Name = "I.T.T. Marconi",
                            PhoneNumber = ""
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Students.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BirthPlaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BirthPlaceId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2002, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BirthPlaceId = 1,
                            Email = "john.doe@gmail.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "+41123456789"
                        });
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Attendees.Attendee", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.CourseAttendees.CourseAttendee", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.Attendees.Attendee", "Attendee")
                        .WithMany("CourseAttendees")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolRegister.API.Entities.Courses.Course", "Course")
                        .WithMany("CourseAttendees")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attendee");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Courses.Course", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.Schools.School", "School")
                        .WithMany()
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Grades.Grade", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.CourseAttendees.CourseAttendee", "CourseAttendee")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId", "AttendeeId");

                    b.Navigation("CourseAttendee");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Schools.School", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.Locations.LocationSchool", "LocationSchool")
                        .WithMany()
                        .HasForeignKey("LocationSchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationSchool");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Students.Student", b =>
                {
                    b.HasOne("SchoolRegister.API.Entities.Locations.LocationStudent", "BirthPlace")
                        .WithMany()
                        .HasForeignKey("BirthPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BirthPlace");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Attendees.Attendee", b =>
                {
                    b.Navigation("CourseAttendees");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.CourseAttendees.CourseAttendee", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("SchoolRegister.API.Entities.Courses.Course", b =>
                {
                    b.Navigation("CourseAttendees");
                });
#pragma warning restore 612, 618
        }
    }
}