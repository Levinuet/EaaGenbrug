using Microsoft.AspNetCore.Mvc;
using Core.Model;
using ServerAPI.Repositories;

namespace HelloBlazor.Server.Controllers
{
    [ApiController]
    [Route("api/ads")] // Changed route to match ads context
    public class AdsController : ControllerBase
    {
        private readonly IMyProfileRepository _adRepository; // Rename to match the context of ads

        public AdsController(IMyProfileRepository adRepository)
        {
            _adRepository = adRepository; // Assign the repository to a private variable
        }

        [HttpGet]
        [Route("getall")] // Route to get all ads
        public IEnumerable<Ad> GetAllAds()
        {
            return _adRepository.GetAllAds();
        }

        [HttpPost]
        [Route("add")] // Route to add a new ad
        public IActionResult AddAd(Ad ad)
        {
            _adRepository.AddAd(ad);
            return Ok(); // It's a good practice to return some status
        }

        [HttpDelete]
        [Route("delete/{id:int}")] // Route to delete an ad by ID
        public IActionResult DeleteAd(int id)
        {
            _adRepository.DeleteAd(id);
            return Ok(); // Confirm deletion with a status
        }

        [HttpPut]
        [Route("update")] // Route to update an ad
        public IActionResult UpdateAd(Ad ad)
        {
            _adRepository.UpdateAd(ad);
            return Ok(); // Confirm update with a status
        }
    }
}