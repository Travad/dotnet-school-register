using SQLitePCL;

namespace SchoolRegister.Api.Data.Repositories.Schools;

public interface ISchoolRepository : IRepository<School>
{
    Task<School?> GetSchoolByIdAsync(int schoolId);
    Task<School?> SearchByNameAsync(string searchTerm);
}