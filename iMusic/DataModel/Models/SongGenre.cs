using System;
namespace iMusic.DataModel.Models
{
    public class SongGenre
    {
        public int SongId { get; set; }
        public Song Song { get; set; }

        public int MusicGenreId { get; set; }
        public MusicGenre MusicGenre { get; set; }
    }
}
