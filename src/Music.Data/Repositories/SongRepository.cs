using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        private readonly MusicContext _context;

        public SongRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Song> GetSongByIdAsync(int id) => await _context.Songs.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}