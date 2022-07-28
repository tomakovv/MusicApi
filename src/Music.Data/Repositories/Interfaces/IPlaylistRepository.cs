using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        Task<Playlist> GetPlaylistByIdAsync(int id);

        Task<Playlist> GetPlaylistWithSongsByIdAsync(int id);
    }
}