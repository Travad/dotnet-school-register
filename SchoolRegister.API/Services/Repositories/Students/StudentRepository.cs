using Microsoft.EntityFrameworkCore;
using SchoolRegister.API.DbContexts;
using SchoolRegister.API.Entities;

namespace SchoolRegister.API.Services.Repositories.Students;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolRegisterDbContext _context;

    public StudentRepository(SchoolRegisterDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Student>> GetAllStudentsAsync() 
        => await _context.Students
            .OrderBy(s => s.LastName)
            .ThenBy(s => s.FirstName)
            .ToListAsync();

    public async Task<Student?> GetStudentByIdAsync(int studentId)
        => await _context.Students
            .Where(s => s.Id == studentId)
            .Include(s => s.Attendees)
            .ThenInclude(a => a.CourseAttendees)
            .ThenInclude(c => c.Grades)
            .FirstOrDefaultAsync();
}