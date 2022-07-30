using Music.Data.Entities;

namespace Music.Data.Repositories.Interfaces
{
    public interface IArtistRepository : IBaseRepository<Artist>
    {
        Task<Artist> GetArtistByIdAsync(int id);
    }
}