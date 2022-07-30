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
            var songs = await _songRepository.GetAllSongsWithMembersAsync();
            return _mapper.Map<IEnumerable<SongDto>>(songs);
        }

        public async Task<SongDto> GetSongById(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            return _mapper.Map<SongDto>(song);
        }

        public async Task<SongDto> AddSongAsync(AddSongDto newSongDto)
        {
            var SongAlreadyAdded = await _songRepository.CheckIfSongExistsAsync(newSongDto.Name);
            if (SongAlreadyAdded)
            {
                return null;
            }
            var song = _mapper.Map<Song>(newSongDto);
            await _songRepository.AddAsync(song);
            return _mapper.Map<SongDto>(song);
        }

        public async Task UpdateSongAsync(int id, UpdateSongDto songDto)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            song = _mapper.Map(songDto, song);
            await _songRepository.UpdateAsync(song);
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _songRepository.GetSongByIdAsync(id);
            await _songRepository.DeleteAsync(song);
        }
    }
}