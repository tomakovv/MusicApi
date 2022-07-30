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
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper, ISongRepository songRepository)
        {
            _playlistRepository = playlistRepository;
            _songRepository = songRepository;
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

        public async Task UpdatePlaylistAsync(int id, AddPlaylistDto playlistDto)
        {
            var playlist = await _playlistRepository.GetPlaylistByIdAsync(id);
            playlist = _mapper.Map(playlistDto, playlist);
            await _playlistRepository.UpdateAsync(playlist);
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _playlistRepository.GetPlaylistByIdAsync(id);
            await _playlistRepository.DeleteAsync(playlist);
        }

        public async Task AddSongToPlaylist(int playlistId, int songId)
        {
            var song = await _songRepository.GetSongByIdAsync(songId);
            await _playlistRepository.AddSongToPlaylist(playlistId, song);
        }

        public async Task DeleteSongFromPlaylist(int playlistId, int songId)
        {
            var song = await _songRepository.GetSongByIdAsync(songId);
            await _playlistRepository.DeleteSongFromPlaylist(playlistId, song);
        }
    }
}