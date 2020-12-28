using System;
using System.Collections.Generic;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iMusic.DataModel.Repository.Implementation
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext context) : base(context) { }

        public List<Album> GetAll()
        {
            return _context.Albums.Include(p => p.Songs).ToList();
        }

        public Album GetByName(string name, string artistName)
        {
            return _context.Albums.Include(p => p.Artist).
                Where(p => p.Name == name && p.Artist.Name == artistName).FirstOrDefault();
        }
    }
}
