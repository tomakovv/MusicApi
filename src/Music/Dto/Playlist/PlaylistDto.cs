﻿using Music.Dto.Song;

namespace Music.Dto.Playlist
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }
}