using Music.Dto.Album;
using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAllAlbumsAsync();

        Task<AlbumDto> GetAlbumByIdAsync(int id);

        Task<AlbumWithSongsDto> GetPlaylistByIdWithSongsAsync(int id);

        Task<SongDto> GetSongFromAlbumAsync(int albumId, int songId);

        Task EditGenreAsync(int id, EditAlbumDto albumDto);

        Task<AlbumDto> AddAlbumAsync(AddAlbumDto albumDto);

        Task DeleteAlbumAsync(int id);
    }
}