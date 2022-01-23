using BulletinBoard.Infrastructure.Enums;
using BulletinBoard.Infrastructure.Models.Database;
using BulletinBoard.Infrastructure.Models.Service.Section;
using BulletinBoard.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet("GetSections")]
        public async Task<IActionResult> GetSections()
        {
            List<SectionDto> sections = await _sectionService.GetSectionsAsync();

            return Ok(sections);
        }

        [HttpGet("GetSection/{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            SectionDto section = await _sectionService.GetSectionByIdAsync(id);

            return Ok(section);
        }

        [HttpGet("GetSectionByName/{name}")]
        public async Task<IActionResult> GetSection(string name)
        {
            SectionDto section = await _sectionService.GetSectionByNameAsync(name);

            return Ok(section);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SectionDto section)
        {
            CreateSectionResponseModel createSectionResponse = await _sectionService.CreateSectionAsync(section);

            if (createSectionResponse.Type == SectionResponseType.Success)
            {
                return Ok(createSectionResponse);
            }

            return BadRequest(createSectionResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, SectionDto section)
        {
            EditSectionResponseModel editSectionResponse = await _sectionService.EditSectionAsync(id, section);

            if (editSectionResponse.Type == SectionResponseType.Success)
            {
                return Ok(editSectionResponse);
            }

            return BadRequest(editSectionResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            SectionResponseType sectionResponse = await _sectionService.DeleteSectionAsync(id);

            if (sectionResponse == SectionResponseType.Success)
            {
                return Ok(sectionResponse);
            }

            return BadRequest(sectionResponse);
        }
    }
}
