using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;
using iMusic.Dto.Model;

namespace iMusic.Mapper
{
    public class MapperToEntity
    {
        public static User Convert(UserDTO userDTO)
        {
            var user = new User()
            {
                UserId = userDTO.UserId != null ? (int)userDTO.UserId : 0,
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password
            };
            return user;
        }

        public static ShoppingCart Convert(ShoppingCartDTO shoppingCartDTO)
        {
            var shoppingCart = new ShoppingCart()
            {
                UserId = (int)shoppingCartDTO.UserId,
                Price = (float)shoppingCartDTO.Price,
                Date = shoppingCartDTO.Date ?? DateTime.Now,
                ShoppingCartItems = Convert(shoppingCartDTO.Cartitems)
            };
            return shoppingCart;
        }

        public static List<ShoppingCartItem> Convert(List<ShoppingCartItemDTO> shoppingCartItemDTOs)
        {
            List<ShoppingCartItem> shoppingCartItems = new List<ShoppingCartItem>();
            shoppingCartItemDTOs.ForEach(p => shoppingCartItems.Add(Convert(p)));
            return shoppingCartItems;
        }

        public static ShoppingCartItem Convert(ShoppingCartItemDTO shoppingCartItemDTO)
        {
            var shoppingCartItem = new ShoppingCartItem()
            {
                Price = (float)shoppingCartItemDTO.Price,
                AlbumId = (int?)shoppingCartItemDTO.AlbumId,
                SongId = (int?)shoppingCartItemDTO.SongId
            };
            return shoppingCartItem;
        }
    }
}
