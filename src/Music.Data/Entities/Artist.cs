namespace Music.Data.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Song> Songs { get; set; }
        public IEnumerable<Album> Albums { get; set; }

        public Artist()
        {
            Songs = new List<Song>();
            Albums = new List<Album>();
        }
    }
}