using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtistByIdAsync(int id);
    }
}