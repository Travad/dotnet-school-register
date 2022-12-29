using SQLitePCL;

namespace SchoolRegister.Api.Data.Repositories.Schools;

public interface ISchoolRepository : IRepository<School>
{
    Task<School?> SearchByNameAsync(string searchTerm);
}