using System;
using iMusic.DataModel.Models;
namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IMusicGenreRepository : IGenericRepository<MusicGenre>
    {
        public MusicGenre GetByName(string name);
    }
}
