using System;
using System.Collections.Generic;
using iMusic.DataModel.Repository.Interfaces;
using iMusic.DataModel.UnitOfWork;
using iMusic.Dto.Model;
using iMusic.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace iMusic.Controllers
{
    [ApiController]
    [Route("/api/albums")]
    public class AlbumController : ControllerBase
    {
        public List<AlbumDTO> GetAlbums()
        {
            using(var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IAlbumRepository>();

                var albumEntities = repo.GetAll();
                return MapperToDTO.Convert(albumEntities);
            }
        }
    }
}
