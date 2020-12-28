using System;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;

namespace iMusic.DataModel.Repository.Implementation
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context) { }

        public Artist GetByName(string name)
        {
            return _context.Artists.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
