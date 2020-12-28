using System;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace iMusic.DataModel.Repository.Implementation
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context) { }

        public Song GetByName(string songName, string artistName)
        {
            return _context.Songs.Include(p => p.ArtistSongs).ThenInclude(z => z.Artist)
                .Where(p => p.Name == songName && p.ArtistSongs.Where(z => z.Artist.Name == artistName).FirstOrDefault() != null)
                .FirstOrDefault();
        }
    }
}
