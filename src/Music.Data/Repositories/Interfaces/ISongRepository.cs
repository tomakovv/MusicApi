using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        Task<IEnumerable<Song>> GetAllSongsWithMembersAsync();

        Task<Song> GetSongByIdAsync(int id);

        Task<bool> CheckIfSongExistsAsync(string songName);
    }
}