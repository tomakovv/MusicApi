namespace Music.Dto.Song
{
    public class AddSongDto
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}