using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IAlbumRepository : IBaseRepository<Album>
    {
        Task<Album> GetAlbumByIdAsync(int id);
    }
}