using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [SwaggerOperation(Summary = "Retrieves all Genres")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genreService.GetAllGenresAsync();
            if (genres is not null)
            {
                return Ok(genres);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific Genre")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre is not null)
            {
                return Ok(genre);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves songs from specific Genre")]
        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync(int id)
        {
            var genre = await _genreService.GetGenreByIdWithSongsAsync(id);
            if (genre is not null)
            {
                return Ok(genre);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific song from Genre")]
        [HttpGet("{genreId}/songs/{songId}")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync([FromRoute] int genreId, [FromRoute] int songId)
        {
            var song = await _genreService.GetSongFromGenre(genreId, songId);
            if (song is not null)
            {
                return Ok(song);
            }
            return NotFound();
        }
    }
}