using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Artist;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;
        public ArtistController (IArtistRepository artistRepo)
        {
            _artistRepo = artistRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectArtist query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artists = await _artistRepo.GetAllAsync(query);

            var artistDto = artists.Select(s => s.ToArtistDto());
            
            return Ok(artistDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artist = await _artistRepo.GetByIdAsync(id);
            
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist.ToArtistDto());
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] CreateArtistDto artistDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artistModel = artistDto.ToArtistFromCreateDTO();
            await _artistRepo.CreateAsync(artistModel);
            return CreatedAtAction(nameof(GetById), new { id = artistModel.Id}, artistModel.ToArtistDto());
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArtistDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artistModel = await _artistRepo.UpdateAsync(id, updateDto);
            if (artistModel == null)
            {
                return NotFound();
            }

            return Ok(artistModel.ToArtistDto());
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artistModel = await _artistRepo.DeleteAsync(id);

              if (artistModel == null)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        [HttpGet("with-average-price")]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> GetArtistWithAvrPrice()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artistsWithAvgPrice = await _artistRepo.GetArtistWithAvrPriceAsync();

            if (artistsWithAvgPrice == null)
            {
                return NotFound();
            }

            return Ok(artistsWithAvgPrice);
        }
    }
}