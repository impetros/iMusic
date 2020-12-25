using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iMusic.DataModel.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        public DateTime Date { get; set; }

        public float Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
