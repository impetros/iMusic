using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;

namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        public List<Album> GetAll();

        public Album GetByName(string name, string artistName);
    }
}
