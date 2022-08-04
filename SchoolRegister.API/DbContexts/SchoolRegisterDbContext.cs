using Microsoft.EntityFrameworkCore;
using SchoolRegister.API.Entities;

namespace SchoolRegister.API.DbContexts;

public class SchoolRegisterDbContext : DbContext
{
    public DbSet<LocationSchool> LocationSchools { get; set; } = null!;
    public DbSet<LocationStudent> LocationStudents { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Attendee> Attendees { get; set; } = null!;
    public DbSet<CourseAttendee> CourseAttendees { get; set; } = null!;
    public DbSet<Grade> Grades { get; set; } = null!;

    public SchoolRegisterDbContext(DbContextOptions<SchoolRegisterDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder
            .Entity<LocationSchool>()
            .HasData(
                new LocationSchool()
                {
                    Id = 1,
                    Country = "Italy",
                    Region = "Molise",
                    Province = "Campobasso",
                    City = "Isernia",
                    Address1 = "Via Camolo, 13A",
                    Cap = "10867"
                }
            );
        
        modelBuilder
            .Entity<School>()
            .HasData(
                new School()
                {
                    Id = 1,
                    Name = "I.T.T. Marconi",
                    Description = "I.T.T. Marconi is a high-tech school with the purpose of providing high-quality IT-oriented education to the students of the province of Trento.",
                    DateOfConstruction = new DateTime(1985, 1, 1),
                    LocationSchoolId = 1,
                }
            );

        modelBuilder
            .Entity<LocationStudent>()
            .HasData(
                new LocationStudent()
                {
                    Id = 1,
                    Country = "Italy",
                    Region = "Molise",
                    Province = "Campobasso",
                    City = "Isernia",
                    Address1 = "Via Proviola, 2A",
                    Cap = "10867"
                }
            );
        
        modelBuilder
            .Entity<Student>()
            .HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(2002, 12, 2),
                    Email = "john.doe@gmail.com",
                    PhoneNumber = "+41123456789",
                    BirthPlaceId = 1,
                }
            );
        
        modelBuilder
            .Entity<Attendee>()
            .HasData(
                new Attendee()
                {
                    Id = 1,
                    StartDay = new DateTime(2020, 07, 12),
                    EndDay = new DateTime(2020, 12, 31),
                    StudentId = 1,
                }
            );
        
        modelBuilder
            .Entity<Course>()
            .HasData(
                new Course()
                {
                    Id = 1,
                    Name = "Web Development",
                    Description = "Web Development course is a course that teaches the basics of web development.",
                    StartDate = new DateTime(2020, 7, 12),
                    EndDate = new DateTime(2020, 12, 31),
                    SchoolId = 1,
                },
                new Course()
                {
                    Id = 2,
                    Name = "Mobile Development",
                    Description = "Mobile Development course is a course that teaches the basics of mobile development.",
                    StartDate = new DateTime(2020, 7, 12),
                    EndDate = new DateTime(2020, 12, 31),
                    SchoolId = 1,
                }
            );
        
        modelBuilder
            .Entity<CourseAttendee>()
            .HasKey(c => new { c.CourseId, c.AttendeeId});
        
        modelBuilder
            .Entity<CourseAttendee>()
            .HasData(
                new CourseAttendee()
                {
                    AttendeeId = 1,
                    CourseId = 1,
                },
                new CourseAttendee()
                {
                    AttendeeId = 1,
                    CourseId = 2,
                }
            );
        
        modelBuilder
            .Entity<Grade>()
            .HasOne(g => g.CourseAttendee)
            .WithMany(g => g.Grades)
            .HasForeignKey(fk => new { fk.CourseId, fk.AttendeeId });
        
        modelBuilder
            .Entity<Grade>()
            .HasData(
                new Grade()
                {
                    Id = 1,
                    RegistrationTime = new DateTime(2020, 10, 3),
                    GradeMark = 8.9,
                    CourseId = 1,
                    AttendeeId = 1,
                }
            );

        base.OnModelCreating(modelBuilder);
    }
}