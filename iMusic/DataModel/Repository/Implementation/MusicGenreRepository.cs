using System;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
namespace iMusic.DataModel.Repository.Implementation
{
    public class MusicGenreRepository : GenericRepository<MusicGenre>, IMusicGenreRepository
    {
        public MusicGenreRepository(AppDbContext context) : base(context) { }

        public MusicGenre GetByName(string name)
        {
            return _context.MusicGenres.Where(p => p.Name == name).FirstOrDefault();
        }

    }
}
