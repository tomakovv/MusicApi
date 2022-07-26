using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetAllSongsAsync();

        Task<SongDto> GetSongById(int id);
    }
}