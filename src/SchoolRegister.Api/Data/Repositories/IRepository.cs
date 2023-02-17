namespace SchoolRegister.Api.Data.Repositories;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity); 
    Task<bool> DeleteAsync(T entity);
    Task<bool> ExistsAsync(T entity);
    Task<bool> SaveChangesAsync();
}