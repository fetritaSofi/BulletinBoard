
using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Advert;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet("GetAdverts")]
        public async Task<IActionResult> GetAdverts()
        {
            List<AdvertDto> adverts = await _advertService.GetAdvertsAsync();

            return Ok(adverts);
        }

        [HttpGet("GetAdvert/{id}")]
        public async Task<IActionResult> GetAdvert(int id)
        {
            AdvertDto advert = await _advertService.GetAdvertByIdAsync(id);

            return Ok(advert);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdvertDto advert)
        {
            CreateAdvertResponseModel createAdvertResponse = await _advertService.CreateAdvertAsync(advert);

            if (createAdvertResponse.Type == AdvertResponseType.Success)
            {
                return Ok(createAdvertResponse);
            }

            return BadRequest(createAdvertResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AdvertDto advert)
        {
            EditAdvertResponseModel editAdvertResponse = await _advertService.EditAdvertAsync(id, advert);

            if (editAdvertResponse.Type == AdvertResponseType.Success)
            {
                return Ok(editAdvertResponse);
            }

            return BadRequest(editAdvertResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AdvertResponseType advertResponse = await _advertService.DeleteAdvertAsync(id);

            if (advertResponse == AdvertResponseType.Success)
            {
                return Ok(advertResponse);
            }

            return BadRequest(advertResponse);
        }
    }
}
