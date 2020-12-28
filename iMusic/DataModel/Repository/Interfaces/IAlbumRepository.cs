using System;
using iMusic.DataModel.Models;

namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        public Album GetByName(string name, string artistName);
    }
}
