using System;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using iMusic.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        [AllowAnonymous]
        public int Register([FromBody]UserDTO userDTO)
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                bool usernameExists = repo.GetByUsername(userDTO.Username) != null;
                if (usernameExists) return 1;
                repo.Add(MapperToEntity.Convert(userDTO));

                uow.Save();
                return 0;
            }
        }
    }
}
