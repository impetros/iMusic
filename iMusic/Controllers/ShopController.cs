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
    [Route("api/shop")]
    public class ShopController
    {
        [HttpPost("purchase")]
        [Authorize(Policy = Policies.User)]
        public void Purchase([FromBody]ShoppingCartDTO cart)
        {
            using (var uow = new UnitOfWork())
            {
                var repo = uow.GetRepository<IShoppingCartRepository>();
                repo.Add(MapperToEntity.Convert(cart));
                uow.Save();
            }
        }
    }
}
