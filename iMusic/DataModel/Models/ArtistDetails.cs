using System;
namespace iMusic.DataModel.Models
{
    public class ArtistDetails
    {
        /* NO KEY */

        public int ArtistId { get; set; } // PK == FK
        public Artist Artist { get; set; }

        public string Bio { get; set; }
    }
}
