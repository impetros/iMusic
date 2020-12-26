using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;

namespace iMusic.DataModel.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetByUsername(string username);

        public User GetByUsernameOrEmailAndPassword(string usernameOrEmail, string password);
    }
}
