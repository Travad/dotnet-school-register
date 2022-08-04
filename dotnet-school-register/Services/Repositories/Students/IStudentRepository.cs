using dotnet_school_register.Entities.Students;

namespace dotnet_school_register.Services.Repositories;

/// <summary>
/// Abstraction layer of the repository pattern for the school register API
/// </summary>
public interface IStudentRepository
{   
    /// <summary>
    /// Retrieve the information for all the students in the repository
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Student>> GetAllStudentsAsync();
}