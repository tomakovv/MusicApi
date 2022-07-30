using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Dto.Artist;
using Music.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [SwaggerOperation(Summary = "Retrieves all Artists")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            if (artists is not null)
            {
                return Ok(artists);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific Artist")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            if (artist is not null)
            {
                return Ok(artist);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Create a new Artist")]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddArtistDto artistDto)
        {
            var newArtist = await _artistService.AddArtistAsync(artistDto);
            return CreatedAtRoute(nameof(GetByIdAsync), new { id = newArtist.Id }, newArtist);
        }

        [SwaggerOperation(Summary = "Edit specific artist")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, EditArtistDto genreDto)
        {
            await _artistService.EditArtistAsync(id, genreDto);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete specific artist")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _artistService.DeleteArtistAsync(id);
            return NoContent();
        }
    }
}