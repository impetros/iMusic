using System;
namespace iMusic.DataModel.Models
{
    public class ArtistSong
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
