namespace Music.Dto.Song
{
    public class UpdateSongDto
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}