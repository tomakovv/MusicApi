using Music.Data.Entities;

namespace Music.Dto.Song
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
    }
}