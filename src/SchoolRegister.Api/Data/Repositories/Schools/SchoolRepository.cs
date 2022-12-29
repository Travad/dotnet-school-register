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
        _context.Schools.Add(entity);
        return await SaveChangesAsync();
    }

    public async Task<IEnumerable<School>> GetAllAsync()
        => await _context.Schools
            .Include(s => s.Courses)
            .Include(s => s.LocationSchool)
            .OrderBy(s => s.Name)
            .ToListAsync();

    public async Task<bool> UpdateAsync(School entity)
    {
        _context.Schools.Update(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(School entity)
    {
        _context.Schools.Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(School other) =>
        await _context.Schools.AnyAsync(dbEntity => dbEntity == other);

    public async Task<bool> SaveChangesAsync() =>
        await _context.SaveChangesAsync() >= 0;

    public async Task<School?> SearchByNameAsync(string? searchTerm)
    {
        ArgumentException.ThrowIfNullOrEmpty(searchTerm);

        return await _context.Schools
            .Where(s => s.Name.ToLower().Contains(searchTerm.Trim().ToLower()))
            .FirstOrDefaultAsync();
    }
}