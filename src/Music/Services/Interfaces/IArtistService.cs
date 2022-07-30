using Music.Dto.Artist;

namespace Music.Services.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> GetAllArtistsAsync();

        Task<ArtistDto> GetArtistByIdAsync(int id);

        Task<ArtistDto> AddArtistAsync(AddArtistDto artistDto);

        Task EditArtistAsync(int id, EditArtistDto artistDto);

        Task DeleteArtistAsync(int id);
    }
}