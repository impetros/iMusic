using System;
using System.Collections.Generic;

namespace iMusic.DataModel.Models
{
    public class Song
    {
        public Int32 SongId { get; set; }

        public string Name { get; set; }

        public float Length { get; set; }

        public float Price { get; set; }

        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public IList<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();

        public IList<SongGenre> SongGenres { get; set; } = new List<SongGenre>();
    }
}
