using Music.Dto.Playlist;
using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDto>> GetAllPlaylistAsync();

        Task<PlaylistDto> GetPlaylistByIdAsync(int id);

        Task<PlaylistDto> GetPlaylistByIdWithSongsAsync(int id);

        Task<SongDto> GetSongFromPlaylistAsync(int playlistId, int songId);

        Task<PlaylistDto> AddPlaylistAsync(AddPlaylistDto playlistDto);

        Task DeletePlaylistAsync(int id);
    }
}