using System;
using System.Collections.Generic;
using iMusic.DataModel.Models;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using iMusic.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("api/songs")]
    public class SongsController : ControllerBase
    {
        [HttpGet]
        public List<SongDTO> GetSongs()
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<ISongRepository>();

                var songEntities = repo.GetAllSongs();

                return MapperToDTO.Convert(songEntities);
            }
        }
    }
}
