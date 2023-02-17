namespace SchoolRegister.Api.Data.Repositories.Schools;

public class SchoolRepository : ISchoolRepository
{
    private readonly SchoolRegisterDbContext _context;

    public SchoolRepository(SchoolRegisterDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<bool> CreateAsync(School entity)
    {
        if (!await ExistsAsync(entity)) 
            await _context.Schools.AddAsync(entity);
        
        return await SaveChangesAsync();
    }

    public async Task<IEnumerable<School>> GetAllAsync()
        => await _context.Schools
            .Include(s => s.LocationSchool)
            .Include(s => s.Courses)
                .ThenInclude(c => c.CourseAttendees)
            .OrderBy(s => s.Name)
            .ToListAsync();

    public async Task<School?> SearchByNameAsync(string? searchTerm)
    {
        ArgumentException.ThrowIfNullOrEmpty(searchTerm);

        return await _context.Schools
            .Where(s => s.Name.ToLower().Contains(searchTerm.Trim().ToLower()))
            .Include(s => s.LocationSchool)
            .Include(s => s.Courses)
                .ThenInclude(c => c.CourseAttendees)
            .FirstOrDefaultAsync();
    }
    public async Task<School?> GetSchoolByIdAsync(int schoolId) => 
        await _context.Schools
            .Include(s => s.LocationSchool)
            .Include(s => s.Courses)
                .ThenInclude(c => c.CourseAttendees)
            .FirstOrDefaultAsync(s => s.Id == schoolId);

    public async Task<bool> UpdateAsync(School entity)
    {
        if (await ExistsAsync(entity))
        {
            _context.Schools.Update(entity);
            return await SaveChangesAsync();
        }

        return false;
    }

    public async Task<bool> DeleteAsync(School entity)
    {
        _context.Schools.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(School other) =>
        await _context.Schools.AnyAsync(dbEntity => dbEntity.Id == other.Id);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() >= 0;
    
}