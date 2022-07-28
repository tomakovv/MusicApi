using Microsoft.EntityFrameworkCore;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MusicContext _context;

        public BaseRepository(MusicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> AddAsync(T entity)
        {
            var addedElement = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedElement.Entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}