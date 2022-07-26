using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class ArtistRepository : BaseRepository<Artist>, IArtistRepository
    {
        private readonly MusicContext _context;

        public ArtistRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Artist> GetArtistByIdAsync(int id) => await _context.Artists.Include(a => a.Songs).Include(a => a.Albums).FirstOrDefaultAsync();
    }
}