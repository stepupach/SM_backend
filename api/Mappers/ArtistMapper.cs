using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Artist;
using api.Models;

namespace api.Mappers
{
    public static class ArtistMapper
    {
        public static ArtistDto ToArtistDto(this Artist artistModel)
        {
            return new ArtistDto
            {
                Id = artistModel.Id,
                FullName = artistModel.FullName,
                SchoolOfPainting = artistModel.SchoolOfPainting,
                DateOfBirth = artistModel.DateOfBirth,
                Exhibits = artistModel.Exhibits.Select(e => e.ToExhibitDto()).ToList()
            };
        }

        public static Artist ToArtistFromCreateDTO(this CreateArtistDto artistDto)
        {
            return new Artist
            {
                FullName = artistDto.FullName,
                SchoolOfPainting = artistDto.SchoolOfPainting,
                DateOfBirth = artistDto.DateOfBirth
            };
        }
    }
}