using System;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using iMusic.Mapper;
using iMusic.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet("user/{id}")]
        [Authorize(Policy = Policies.User)]
        public UserDTO GetUser(int id)
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                var userEntity = repo.GetById(id);
                return MapperToDTO.Convert(userEntity);
            }
        }

        [HttpPut("update")]
        [Authorize(Policy = Policies.User)]
        public int Update([FromBody] UserDTO userDTO)
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                bool usernameExists = repo.GetByUsername(userDTO.Username) != null;
                if (usernameExists) return 1;
                repo.Update(MapperToEntity.Convert(userDTO));

                uow.Save();
                return 0;
            }
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Policy = Policies.User)]
        public int Delete(int id)
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();
                repo.Delete(id);
                uow.Save();
                return 0;
            }
        }


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
