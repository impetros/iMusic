using System;
using System.Collections.Generic;
using System.Linq;
using iMusic.DataModel.Context;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;

namespace iMusic.DataModel.Repository.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public User GetByUsername(string username)
        {
            return _context.Users.Where(p => p.Username == username).FirstOrDefault();
        }

        public User GetByUsernameOrEmailAndPassword(string usernameOrEmail, string password)
        {
            return _context.Users.Where(p => (p.Email == usernameOrEmail || p.Username == usernameOrEmail) &&
                                              p.Password == password).FirstOrDefault();
        }
    }
}
