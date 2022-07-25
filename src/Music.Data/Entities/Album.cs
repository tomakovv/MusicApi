namespace Music.Data.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Song> Songs { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }
}