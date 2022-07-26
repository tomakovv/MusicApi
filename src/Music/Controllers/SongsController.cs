using Microsoft.AspNetCore.Mvc;
using Music.Dto.Song;
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
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var songs = await _songService.GetAllSongsAsync();
            if (songs is not null)
            {
                return Ok(songs);
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

        [SwaggerOperation(Summary = "Add specific song ")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddSongDto songDto)
        {
            var song = await _songService.AddSongAsync(songDto);

            return Created($"api/songs/{song.Id}", song);
        }

        [SwaggerOperation(Summary = "Update specific song ")]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateSongDto songDto)
        {
            await _songService.UpdateSongAsync(songDto);
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