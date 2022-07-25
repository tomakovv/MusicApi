using Microsoft.EntityFrameworkCore;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Func<T, bool> condition) => _context.Set<T>().AsNoTracking().Where(condition).FirstOrDefault();

        public IEnumerable<T> GetAll() => _context.Set<T>().AsNoTracking().ToList();
    }
}