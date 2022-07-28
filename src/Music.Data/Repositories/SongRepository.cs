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

        public async Task<IEnumerable<Song>> GetAllSongsWithMembersAsync() => await _context.Songs.Include(s => s.Genre).Include(s => s.Artist).AsNoTracking().ToListAsync();

        public async Task<Song> GetSongByIdAsync(int id) => await _context.Songs.Include(s => s.Genre).Include(s => s.Artist).Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}