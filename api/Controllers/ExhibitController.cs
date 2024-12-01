using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Exhibit;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/exhibit")]
    [ApiController]
    public class ExhibitController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IExhibitRepository _exhibitRepo;
        private readonly IArtistRepository _artistRepo;
        public ExhibitController(IExhibitRepository exhibitRepo, IArtistRepository artistRepo)
        {
            _exhibitRepo = exhibitRepo;
            _artistRepo = artistRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectExhibit query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibits = await _exhibitRepo.GetAllAsync(query); // отложенное выполнение
            
            var exhibitDto = exhibits.Select(e => e.ToExhibitDto());

            return Ok(exhibits);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibit =  await _exhibitRepo.GetByIdAsync(id);

            if (exhibit == null)
            {
                return NotFound();
            }

            return Ok(exhibit.ToExhibitDto());
        }

        [HttpPost("{artistId:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromRoute] int artistId, CreateExhibitDto exhibitDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!await _artistRepo.ArtistsExists(artistId))
            {
                return BadRequest("Такого художника нет");
            }

            var exhibitModel = exhibitDto.ToExhibitFromCreate(artistId);
            await _exhibitRepo.CreateAsync(exhibitModel);
            return CreatedAtAction(nameof(GetById), new {id = exhibitModel.Id}, exhibitModel.ToExhibitDto());
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExhibitPriceDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibit = await _exhibitRepo.UpdateAsync(id, updateDto);
            if (exhibit == null)
            {
                return NotFound("Произведение не найдено");
            }

            return Ok(exhibit.ToExhibitDto());
        }

        
        [HttpPut("{id}/sell-exhibit")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Sell(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibit = await _exhibitRepo.SellAsync(id);
            if (exhibit == null)
            {
                return NotFound("Произведение не найдено");
            }

            return Ok(exhibit.ToExhibitDto());
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibitModel = await _exhibitRepo.DeleteAsync(id);

              if (exhibitModel == null)
            {
                return NotFound("Произведение не найдено");
            }

            return NoContent(); 
        }

        [HttpGet("with-school-of-painting")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetExhibitWithSchoolOfPainting()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exhibitWithSchoolOfPainting = await _exhibitRepo.GetExhibitWithSchoolOfPaintingAsync();

            if (exhibitWithSchoolOfPainting == null)
            {
                return NotFound();
            }

            return Ok(exhibitWithSchoolOfPainting);
        }
    }
}