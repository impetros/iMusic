using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;
namespace iMusic.DataModel.Repository.Interfaces
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        public List<Song> GetAllSongs();

        public Song GetByName(string songName, string artistName);
    }
}
