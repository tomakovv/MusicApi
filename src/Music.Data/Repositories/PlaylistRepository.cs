using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class PlaylistRepository : BaseRepository<Playlist>, IPlaylistRepository
    {
        private readonly MusicContext _context;

        public PlaylistRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Playlist> GetPlaylistByIdAsync(int id) => await _context.Playlists.Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task<Playlist> GetPlaylistWithSongsByIdAsync(int id) => await _context.Playlists.Include(p => p.Songs).Where(s => s.Id == id).FirstOrDefaultAsync();
    }
}