using AutoMapper;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Genre;
using Music.Dto.Song;
using Music.Services.Interfaces;

namespace Music.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GenreDto>>(genres);
        }

        public async Task<GenreDto> GetGenreByIdAsync(int id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            return _mapper.Map<GenreDto>(genre);
        }

        public async Task<GenreWithSongsDto> GetGenreByIdWithSongsAsync(int id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            return _mapper.Map<GenreWithSongsDto>(genre);
        }

        public async Task<SongDto> GetSongFromGenre(int genreId, int songId)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(genreId);
            if (genre.Songs.Any(s => s.Id == songId))
            {
                var song = genre.Songs.Where(s => s.Id == songId).First();
                return _mapper.Map<SongDto>(song);
            }
            return null;
        }
    }
}