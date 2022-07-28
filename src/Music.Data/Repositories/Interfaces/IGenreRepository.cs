using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<Genre> GetGenreByIdAsync(int id);
    }
}