using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetAllSongsAsync();

        Task<SongDto> GetSongById(int id);

        Task<OperationResult<SongDto>> AddSongAsync(AddSongDto song);

        Task<OperationResult> UpdateSongAsync(int id, UpdateSongDto songDto);

        Task DeleteSongAsync(int id);
    }
}