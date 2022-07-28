﻿using Microsoft.AspNetCore.Mvc;
using Music.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Music.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistsController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [SwaggerOperation(Summary = "Retrieves all Playlists")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var playlists = await _playlistService.GetAllPlaylistAsync();
            if (playlists is not null)
            {
                return Ok(playlists);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific Playlist")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdAsync(id);
            if (playlist is not null)
            {
                return Ok(playlist);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves songs from specific Playlist")]
        [HttpGet("{id}/songs")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync(int id)
        {
            var playlist = await _playlistService.GetPlaylistByIdWithSongsAsync(id);
            if (playlist is not null)
            {
                return Ok(playlist);
            }
            return NotFound();
        }

        [SwaggerOperation(Summary = "Retrieves specific song from Playlist")]
        [HttpGet("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> GetSongsFromPlaylistAsync([FromRoute] int playlistId, [FromRoute] int songId)
        {
            var song = await _playlistService.GetSongFromPlaylist(playlistId, songId);
            if (song is not null)
            {
                return Ok(song);
            }
            return NotFound();
        }
    }
}