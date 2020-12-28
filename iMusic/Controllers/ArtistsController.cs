using System;
using System.Collections.Generic;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using iMusic.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public List<ArtistDTO> GetAllArtists()
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IArtistRepository>();

                var artistEntities = repo.GetAll();

                return MapperToDTO.Convert(artistEntities);
            }
        }
    }
}
