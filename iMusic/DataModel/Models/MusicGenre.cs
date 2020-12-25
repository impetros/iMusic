using System;
using System.Collections.Generic;

namespace iMusic.DataModel.Models
{
    public class MusicGenre
    {
        public int MusicGenreId { get; set; }

        public string Name { get; set; }

        public IList<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
    }
}
