using Microsoft.EntityFrameworkCore;
using Location = SchoolRegister.Models.Entities.Location;

namespace SchoolRegister.Api.Data.Contexts;

public class SchoolRegisterDbContext : DbContext
{
    // Database tables (mapping to C# entities)
    public DbSet<Location> LocationSchools { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Attendee> Attendees { get; set; } = null!;
    public DbSet<CourseAttendee> CourseAttendees { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;
    
    public SchoolRegisterDbContext(DbContextOptions<SchoolRegisterDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Guid locationGuid1 = Guid.NewGuid();
        Guid locationGuid2 = Guid.NewGuid();
        Guid schoolGuid1 = Guid.NewGuid();
        Guid studentGuid1 = Guid.NewGuid();
        Guid attendeeGuid1 = Guid.NewGuid();
        Guid courseGuid1 = Guid.NewGuid();
        Guid courseGuid2 = Guid.NewGuid();
        Guid gradeGuid1 = Guid.NewGuid();
        
        modelBuilder.Entity<Location>(locationSchoolEntity =>
        {
            locationSchoolEntity.HasData(
                new Location()
                {
                    Id = locationGuid1,
                    Country = "Italy",
                    Region = "Molise",
                    Province = "Campobasso",
                    City = "Isernia",
                    Address1 = "Via Camolo, 13A",
                    Cap = "10867",
                },
                new Location()
                {
                    Id = locationGuid2,
                    Country = "Italy",
                    Region = "Molise",
                    Province = "Campobasso",
                    City = "Isernia",
                    Address1 = "Via Proviola, 2A",
                    Cap = "10867"
                });
        });

        modelBuilder.Entity<School>(schoolEntity =>
        {
            schoolEntity.HasData(
                new School()
                {
                    Id = schoolGuid1,
                    Name = "I.T.T. Marconi",
                    Email = "info@ittmarconi.it",
                    PhoneNumber = "+390474560781",
                    Description =
                        "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.",
                    DateOfConstruction = new DateTime(1985, 1, 1),
                    LocationSchoolId = locationGuid1,
                });
        });

        modelBuilder.Entity<Student>(studentEntity =>
        {
            studentEntity.HasData(
                new Student()
                {
                    Id = studentGuid1,
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(2002, 12, 2),
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "+41123456789",
                    BirthPlaceId = locationGuid2,
                });
        });

        modelBuilder.Entity<Attendee>(attendeeEntity =>
        {
            attendeeEntity.HasData(
                new Attendee()
                {
                    Id = attendeeGuid1,
                    StartDay = new DateTime(2020, 07, 12),
                    EndDay = new DateTime(2020, 12, 31),
                    StudentId = studentGuid1
                });
        });

        modelBuilder.Entity<Course>(courseEntity =>
        {
            courseEntity.HasData(
                new Course()
                {
                    Id = courseGuid1,
                    Name = "Web Development",
                    Description = "Web Development course is a course that teaches the basics of web development.",
                    StartDate = new DateTime(2020, 7, 12),
                    EndDate = new DateTime(2020, 12, 31),
                    SchoolId = schoolGuid1
                },
                new Course()
                {
                    Id = courseGuid2,
                    Name = "Mobile Development",
                    Description =
                        "Mobile Development course is a course that teaches the basics of mobile development.",
                    StartDate = new DateTime(2020, 7, 12),
                    EndDate = new DateTime(2020, 12, 31),
                    SchoolId = schoolGuid1,
                }
            );
        });

        modelBuilder.Entity<CourseAttendee>(courseAttendee =>
        {
            courseAttendee
                .HasKey(c => new { c.CourseId, c.AttendeeId });

            courseAttendee
                .HasData(
                    new CourseAttendee()
                    {
                        AttendeeId = attendeeGuid1,
                        CourseId = courseGuid1,
                    },
                    new CourseAttendee()
                    {
                        AttendeeId = attendeeGuid1,
                        CourseId = courseGuid2,
                    }
                );
        });

        modelBuilder.Entity<Grade>(gradeEntity =>
        {
            gradeEntity
                .HasOne(g => g.CourseAttendee)
                .WithMany(g => g.Grades)
                .HasForeignKey(fk => new { fk.CourseId, fk.AttendeeId });

            gradeEntity.HasData(
                new Grade()
                {
                    Id = gradeGuid1,
                    RegistrationTime = new DateTime(2020, 10, 3),
                    GradeMark = 8.9,
                    CourseId = courseGuid1,
                    AttendeeId = attendeeGuid1,
                });
        });
        
        base.OnModelCreating(modelBuilder);
    }
    
}