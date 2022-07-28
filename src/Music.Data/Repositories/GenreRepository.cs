using Microsoft.EntityFrameworkCore;
using Music.Data.Entities;
using Music.Data.Repositories.Interfaces;

namespace Music.Data.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        private readonly MusicContext _context;

        public GenreRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Genre> GetGenreByIdAsync(int id) => await _context.Genres.Include(g => g.Songs).FirstOrDefaultAsync();
    }
}