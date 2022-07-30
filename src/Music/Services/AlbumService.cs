using AutoMapper;
using Music.Data.Entities;
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

        public async Task<SongDto> GetSongFromAlbumAsync(int albumId, int songId)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(albumId);
            if (album.Songs.Any(s => s.Id == songId))
            {
                var song = album.Songs.Where(s => s.Id == songId).First();
                return _mapper.Map<SongDto>(song);
            }
            return null;
        }

        public async Task EditGenreAsync(int id, EditAlbumDto albumDto)
        {
            var album = await _albumRepository.GetAlbumByIdAsync(id);
            _mapper.Map(albumDto, album);
            await _albumRepository.UpdateAsync(album);
        }

        public async Task<AlbumDto> AddAlbumAsync(AddAlbumDto albumDto)
        {
            var newAlbum = _mapper.Map<Album>(albumDto);
            var addedAlbum = await _albumRepository.AddAsync(newAlbum);
            return _mapper.Map<AlbumDto>(addedAlbum);
        }

        public async Task DeleteAlbumAsync(int id)
        {
            var genre = await _albumRepository.GetAlbumByIdAsync(id);
            await _albumRepository.DeleteAsync(genre);
        }
    }
}