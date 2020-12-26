using System;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Implementation;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;

namespace iMusic
{
    public class FillMockDataDb
    {
        public static void Fill()
        {
            using(var uow = new UnitOfWork())
            {
                var userRepo = uow.GetRepository<IUserRepository>();

                var defaultUser = userRepo.GetByUsername("zarzand");
                if(defaultUser == null)
                {
                    var newUser = new User()
                    {
                        Username = "zarzand",
                        Email = "zarzand@gmail.com",
                        Password = "zarzand"
                    };
                    userRepo.Add(newUser);
                }

                uow.Save();
            }
        }
    }
}
