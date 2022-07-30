using AutoMapper;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;
using Music.Dto.Artist;
using Music.Services.Interfaces;

namespace Music.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtistsAsync()
        {
            var artists = await _artistRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArtistDto>>(artists);
        }

        public async Task<ArtistDto> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(id);
            return _mapper.Map<ArtistDto>(artist);
        }

        public async Task<ArtistDto> AddArtistAsync(AddArtistDto artistDto)
        {
            var newArtist = _mapper.Map<Artist>(artistDto);
            var genre = await _artistRepository.AddAsync(newArtist);
            return _mapper.Map<ArtistDto>(genre);
        }

        public async Task EditArtistAsync(int id, EditArtistDto artistDto)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(id);
            _mapper.Map(artistDto, artist);
            await _artistRepository.UpdateAsync(artist);
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _artistRepository.GetArtistByIdAsync(id);
            await _artistRepository.DeleteAsync(artist);
        }
    }
}