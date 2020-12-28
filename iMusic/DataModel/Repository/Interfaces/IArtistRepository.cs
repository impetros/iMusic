using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;
namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        public List<Artist> GetAll();
        public Artist GetByName(string name);
    }
}
