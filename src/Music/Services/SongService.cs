using AutoMapper;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Song;
using Music.Services.Interfaces;

namespace Music.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _mapper = mapper;
            _songRepository = songRepository;
        }

        public async Task<IEnumerable<SongDto>> GetAllSongsAsync()
        {
            var songs = _songRepository.GetAllSongsWithMembersAsync();
            return _mapper.Map<IEnumerable<SongDto>>(songs.Result);
        }

        public async Task<SongDto> GetSongById(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            return _mapper.Map<SongDto>(song);
        }
    }
}