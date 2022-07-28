using Music.Dto.Genre;
using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();

        Task<GenreDto> GetGenreByIdAsync(int id);

        Task<GenreWithSongsDto> GetGenreByIdWithSongsAsync(int id);

        Task<SongDto> GetSongFromGenre(int genreId, int songId);
    }
}