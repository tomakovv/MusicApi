using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetAllSongsAsync();

        Task<SongDto> GetSongById(int id);

        Task<SongDto> AddSongAsync(AddSongDto song);

        Task UpdateSongAsync(UpdateSongDto songDto);

        Task DeleteSongAsync(int id);
    }
}