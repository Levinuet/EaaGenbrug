﻿using Microsoft.AspNetCore.Mvc;
using Core.Model;
using ServerAPI.Repositories;

namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/eaagenbrug")]
    public class ShoppingController : ControllerBase
    {
        private IAdRepository mRepo;
        public ShoppingController(IAdRepository repo)
        {
            mRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Ad> GetAll()
        {
            return mRepo.GetAll();
        }

        [HttpPost]
        [Route("add")]
        public void AddItem(Ad product)
        {
            mRepo.AddAd(product);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public void DeleteItem(int id)
        {
            mRepo.DeleteById(id);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateItem(Ad product)
        {
            mRepo.UpdateAd(product);
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseAd([FromBody] Ad ad)
        {
            mRepo.PurchaseAd(ad);
            return Ok();

        }

        [HttpPost("approve")]
        public async Task<IActionResult> ApproveAd([FromBody] Ad ad)
        {
            mRepo.ApproveAd(ad);
            return Ok();

        }    
    }
}