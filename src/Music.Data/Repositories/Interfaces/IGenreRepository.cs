using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> GetGenreByIdAsync(int id);
    }
}