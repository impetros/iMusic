﻿using System;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
namespace iMusic.DataModel.Repository.Implementation
{

    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(AppDbContext context) : base(context) { }

    }
}
