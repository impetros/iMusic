using System;
using iMusic.DataModel.Models;
namespace iMusic.DataModel.Repository.Interfaces
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        public Song GetByName(string songName, string artistName);
    }
}
