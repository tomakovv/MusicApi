using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        private readonly MusicContext _context;

        public AlbumRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Album> GetAlbumByIdAsync(int id) => await _context.Albums.Include(a => a.Songs).FirstOrDefaultAsync();
    }
}