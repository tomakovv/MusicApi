using AutoMapper;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Album;
using Music.Dto.Song;
using Music.Services.Interfaces;

namespace Music.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AlbumDto>> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AlbumDto>>(albums);
        }

        public async Task<AlbumDto> GetAlbumByIdAsync(int id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            return _mapper.Map<AlbumDto>(album);
        }

        public async Task<AlbumWithSongsDto> GetPlaylistByIdWithSongsAsync(int id)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            return _mapper.Map<AlbumWithSongsDto>(album);
        }

        public async Task<SongDto> GetSongFromAlbum(int albumId, int songId)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(albumId);
            if (album.Songs.Any(s => s.Id == songId))
            {
                var song = album.Songs.Where(s => s.Id == songId).First();
                return _mapper.Map<SongDto>(song);
            }
            return null;
        }
    }
}