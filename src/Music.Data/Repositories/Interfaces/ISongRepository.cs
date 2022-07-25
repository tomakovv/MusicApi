using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<Song> GetSongByIdAsync(int id);
    }
}