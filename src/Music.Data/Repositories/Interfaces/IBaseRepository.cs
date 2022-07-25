namespace Music.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
    }
}