namespace Music.Dto.Song
{
    public class UpdateSongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}