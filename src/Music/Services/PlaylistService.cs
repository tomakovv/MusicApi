using AutoMapper;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Playlist;
using Music.Dto.Song;
using Music.Services.Interfaces;

namespace Music.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository songRepository, IMapper mapper)
        {
            _playlistRepository = songRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaylistDto>> GetAllPlaylistAsync()
        {
            var playlists = await _playlistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaylistDto>>(playlists);
        }

        public async Task<PlaylistDto> GetPlaylistByIdAsync(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistByIdAsync(id);
            return _mapper.Map<PlaylistDto>(playlist);
        }

        public async Task<PlaylistDto> GetPlaylistByIdWithSongsAsync(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistWithSongsByIdAsync(id);
            return _mapper.Map<PlaylistDto>(playlist);
        }

        public async Task<SongDto> GetSongFromPlaylistAsync(int playlistId, int songId)
        {
            var playlist = await _playlistRepository.GetPlaylistWithSongsByIdAsync(playlistId);
            if (playlist.Songs.Any(s => s.Id == songId))
            {
                var song = playlist.Songs.Where(s => s.Id == songId).First();
                return _mapper.Map<SongDto>(song);
            }
            return null;
        }

        public async Task<PlaylistDto> AddPlaylistAsync(AddPlaylistDto playlistDto)
        {
            if (!await _playlistRepository.IsPlaylistExistAsync(playlistDto.Name))
            {
                var playlist = await _playlistRepository.AddAsync(new Playlist() { Name = playlistDto.Name });
                return _mapper.Map<PlaylistDto>(playlist);
            }
            return null;
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistByIdAsync(id);
            await _playlistRepository.DeleteAsync(playlist);
        }
    }
}