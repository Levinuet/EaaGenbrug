﻿using Microsoft.AspNetCore.Mvc;
using Core.Model;
using ServerAPI.Repositories;

namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/shopping")]
    public class ShoppingController : ControllerBase
    {
        private IAdRepository mRepo;

        public ShoppingController(IAdRepository repo)
        {
            mRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<AdItem> GetAll()
        {
            return mRepo.GetAll();
        }



        [HttpPost]
        [Route("add")]
        public void AddItem(AdItem product)
        {
            mRepo.AddItem(product);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void DeleteItem(int id)
        {
            mRepo.DeleteById(id);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateItem(AdItem product)
        {
            mRepo.UpdateItem(product);
        }

    }
}
