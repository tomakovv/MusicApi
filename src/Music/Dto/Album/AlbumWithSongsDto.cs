using Music.Dto.Song;

namespace Music.Dto.Album
{
    public class AlbumWithSongsDto
    {
        public string Name { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}