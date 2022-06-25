using dotnet_school_register.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace dotnet_school_register.DbContexts;

public class SchoolRegisterDbContext : DbContext
{
    public DbSet<LocationSchool> LocationSchools { get; set; } = null!;
    public DbSet<LocationStudent> LocationStudents { get; set; } = null!;

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
        
        base.OnModelCreating(modelBuilder);
    }
}