using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [SwaggerOperation(Summary = "Retrieves all Albums")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            if (albums is not null)
            {
                return Ok(albums);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific Album")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);
            if (album is not null)
            {
                return Ok(album);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves songs from specific Album")]
        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync(int id)
        {
            var album = await _albumService.GetPlaylistByIdWithSongsAsync(id);
            if (album is not null)
            {
                return Ok(album);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific song from Album")]
        [HttpGet("{albumId}/songs/{songId}")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync([FromRoute] int albumId, [FromRoute] int songId)
        {
            var song = await _albumService.GetSongFromAlbum(albumId, songId);
            if (song is not null)
            {
                return Ok(song);
            }
            return NotFound();
        }
    }
}