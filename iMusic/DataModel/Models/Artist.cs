using System;
using System.Collections.Generic;

namespace iMusic.DataModel.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public virtual ArtistDetails ArtistDetails { get; set; }

        public ICollection<Album> Albums { get; set; }

        public IList<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
