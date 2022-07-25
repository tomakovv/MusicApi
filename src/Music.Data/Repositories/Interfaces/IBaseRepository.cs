namespace Music.Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);

        void Delete(T entity);

        T Get(Func<T, bool> condition);

        IEnumerable<T> GetAll();
    }
}