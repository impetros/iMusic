using System;
using System.Collections.Generic;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;

namespace iMusic.DataModel.Repository.Implementation
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context) { }

        public List<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public Artist GetByName(string name)
        {
            return _context.Artists.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
