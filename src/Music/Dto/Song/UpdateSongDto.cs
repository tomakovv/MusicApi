using System.ComponentModel.DataAnnotations;

namespace Music.Dto.Song
{
    public class UpdateSongDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ArtistId { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}