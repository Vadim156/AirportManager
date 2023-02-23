using FinalProj.Dal;
using Microsoft.EntityFrameworkCore;

namespace Logic.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AirportDbContext _context;
        public GenericRepository(AirportDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
                throw new Exception($"Entity Can Not Be Null");

            await _context.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task DeleteAsync(string id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(IEnumerable<string> id)
        {
            foreach (var guid in id)
            {
                var entity = await GetAsync(guid);
                _context.Set<T>().Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }
        //public async Task<bool> ExistsNumber(int Number)
        //{
        //    var entity = await _context.Set<T>().(Number);
        //    return entity != null;
        //}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(string? id)
        {
            if (id == null)
                return null;
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

