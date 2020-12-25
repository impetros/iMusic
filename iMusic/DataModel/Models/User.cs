using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iMusic.DataModel.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
