using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;

namespace Music.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}