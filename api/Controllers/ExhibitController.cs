using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Exhibit;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("api/exhibit")]
    [ApiController]
    public class ExhibitController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IExhibitRepository _exhibitRepo;
        public ExhibitController(ApplicationDBContext context, IExhibitRepository exhibitRepo)
        {
            _exhibitRepo = exhibitRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var exhibits = await _exhibitRepo.GetAllAsync(); // отложенное выполнение
            
            var exhibitDto = exhibits.Select(e => e.ToExhibitDto());

            return Ok(exhibits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exhibit =  await _exhibitRepo.GetByIdAsync(id);

            if (exhibit == null)
            {
                return NotFound();
            }

            return Ok(exhibit.ToExhibitDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExhibitRequestDto exhibitDto)
        {
            var exhibitModel = exhibitDto.ToExhibitFromCreateDTO();
            await _exhibitRepo.CreateAsync(exhibitModel);
            return CreatedAtAction(nameof(GetById), new { id = exhibitModel.Id}, exhibitModel.ToExhibitDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateExhibitRequestDto updateDto)
        {
            var exhibitModel = await _exhibitRepo.UpdateAsync(id, updateDto);
            if (exhibitModel == null)
            {
                return NotFound();
            }

            return Ok(exhibitModel.ToExhibitDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var exhibitModel = await _exhibitRepo.DeleteAsync(id);

              if (exhibitModel == null)
            {
                return NotFound();
            }

            return NoContent(); 
        }
    }
}