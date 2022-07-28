using Music.Dto.Song;

namespace Music.Dto.Genre
{
    public class GenreWithSongsDto
    {
        public string Name { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}