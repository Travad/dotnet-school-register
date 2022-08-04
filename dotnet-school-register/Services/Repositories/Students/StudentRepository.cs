using dotnet_school_register.DbContexts;
using dotnet_school_register.Entities.Students;
using Microsoft.EntityFrameworkCore;

namespace dotnet_school_register.Services.Repositories;

public class SchoolRegisterRepository : IStudentRepository
{
    private readonly SchoolRegisterDbContext _context;

    public SchoolRegisterRepository(SchoolRegisterDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Student>> GetAllStudentsAsync() 
        => await _context.Students
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToListAsync();

}