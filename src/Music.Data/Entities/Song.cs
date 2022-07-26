using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public Album? Album { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public IEnumerable<Playlist> Playlist { get; set; }

        public Song()
        {
            Playlist = new List<Playlist>();
        }
    }
}