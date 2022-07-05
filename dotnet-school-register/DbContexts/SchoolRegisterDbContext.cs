using dotnet_school_register.Entities.Locations;
using dotnet_school_register.Entities.Schools;
using dotnet_school_register.Entities.Students;
using Microsoft.EntityFrameworkCore;

namespace dotnet_school_register.DbContexts;

public class SchoolRegisterDbContext : DbContext
{
    public DbSet<LocationSchool> LocationSchools { get; set; } = null!;
    public DbSet<LocationStudent> LocationStudents { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;

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

        base.OnModelCreating(modelBuilder);
    }
}