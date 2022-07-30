using Microsoft.AspNetCore.Mvc;
using Music.Dto.Song;
using Music.Services.Interfaces;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;
        private readonly ILogger<SongsController> _logger;

        public SongsController(ISongService songService, ILogger<SongsController> logger)
        {
            _songService = songService;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Retrieves all Songs")]
        [HttpGet]
        public async Task<IActionResult> GetAllSongsAsync()
        {
            _logger.LogInformation("Retrieves all Songs");
            var songs = await _songService.GetAllSongsAsync();
            if (songs == null || songs.Count() == 0)
            {
                return NotFound();
            }
            return Ok(songs);
        }

        [SwaggerOperation(Summary = "Retrieves specific song by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var song = await _songService.GetSongById(id);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        [SwaggerOperation(Summary = "Add specific song ")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddSongDto songDto)
        {
            var song = await _songService.AddSongAsync(songDto);
            if (song == null)
            {
                return BadRequest();
            }
            return Created($"api/songs/{song.Id}", song);
        }

        [SwaggerOperation(Summary = "Update specific song ")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(int id, UpdateSongDto songDto)
        {
            await _songService.UpdateSongAsync(id, songDto);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete specific song ")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _songService.DeleteSongAsync(id);
            return NoContent();
        }
    }
}