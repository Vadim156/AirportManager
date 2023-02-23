using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetAsync(string? id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<bool> Exists(string id);
        Task DeleteAsync(string id);
        Task DeleteAllAsync(IEnumerable<string> id);
        Task UpdateAsync(T entity);
    }
}
