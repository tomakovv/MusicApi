using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IPlaylistRepository : IBaseRepository<Playlist>
    {
        Task<Playlist> GetPlaylistByIdAsync(int id);

        Task<Playlist> GetPlaylistWithSongsByIdAsync(int id);

        Task<bool> IsPlaylistExistAsync(string name);

        Task AddSongToPlaylist(int id, Song song);

        Task DeleteSongFromPlaylist(int id, Song song);
    }
}