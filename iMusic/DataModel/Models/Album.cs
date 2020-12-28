using System;
using System.Collections.Generic;

namespace iMusic.DataModel.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public byte[] Image { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<Song> Songs { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
