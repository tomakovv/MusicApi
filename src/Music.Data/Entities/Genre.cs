﻿namespace Music.Data.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Song> Songs { get; set; }

        public Genre()
        {
        }
    }
}