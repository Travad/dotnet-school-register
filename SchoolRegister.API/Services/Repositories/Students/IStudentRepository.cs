using SchoolRegister.Models.Entities;

namespace SchoolRegister.API.Services.Repositories.Students;

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
    
    /// <summary>
    /// Retrieve the information for a single student in the repository
    /// </summary>
    /// <param name="id">ID of the student to retrieve</param>
    /// <returns></returns>
    Task<Student?> GetStudentByIdAsync(int studentId);
}