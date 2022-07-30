using Music.Dto.Genre;
using Music.Dto.Song;

namespace Music.Services.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();

        Task<GenreDto> GetGenreByIdAsync(int id);

        Task<GenreWithSongsDto> GetGenreByIdWithSongsAsync(int id);

        Task<SongDto> GetSongFromGenreAsync(int genreId, int songId);

        Task<GenreDto> AddGenreAsync(AddGenreDto genreDto);

        Task EditGenreAsync(int id, EditGenreDto genreDto);

        Task DeleteGenreAsync(int id);
    }
}