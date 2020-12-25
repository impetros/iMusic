using System;
namespace iMusic.DataModel.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public float Price { get; set; }

        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public int? SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
