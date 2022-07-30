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

        public async Task<bool> IsPlaylistExistAsync(string name) => await _context.Playlists.Where(s => s.Name == name).AnyAsync();

        public async Task AddSongToPlaylist(int id, Song song)
        {
            var playlist = await GetPlaylistWithSongsByIdAsync(id);
            var songs = playlist.Songs.ToList();
            songs.Add(song);
            playlist.Songs = songs;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSongFromPlaylist(int id, Song song)
        {
            var playlist = await GetPlaylistWithSongsByIdAsync(id);
            var songs = playlist.Songs.ToList();
            songs.Remove(song);
            playlist.Songs = songs;
            await _context.SaveChangesAsync();
        }
    }
}