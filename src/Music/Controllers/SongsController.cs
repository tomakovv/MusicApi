using Microsoft.AspNetCore.Mvc;
using Music.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [SwaggerOperation(Summary = "Retrieves all Songs")]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            var songs = _songService.GetAllSongsAsync();
            if (songs is not null)
            {
                return Ok(songs.Result);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific song by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var song = await _songService.GetSongById(id);
            if (song is not null)
            {
                return Ok(song);
            }
            return NotFound();
        }
    }
}