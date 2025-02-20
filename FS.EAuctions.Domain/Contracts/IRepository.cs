using Microsoft.AspNetCore.Mvc;

namespace Fs.EAuctions.Domain.Contracts;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<ActionResult> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
