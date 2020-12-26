using System;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;

namespace iMusic.DataModel.Repository.Implementation
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext context) : base(context) { }

    }
}
