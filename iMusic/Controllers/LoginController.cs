using System;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            IActionResult response = Unauthorized();
            User user = AuthenticateUser(loginRequest);
            if (user != null)
            {
                var tokenString = iMusic.OAuth2.Utils.GenerateJWT(user, _config);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }
            return response;
        }

        private User AuthenticateUser(LoginRequest login)
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IUserRepository>();

                return repo.GetByUsernameOrEmailAndPassword(login.EmailOrUsername, login.Password);
            }
        }
    }
}
