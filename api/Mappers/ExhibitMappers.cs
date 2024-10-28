using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Exhibit;
using api.Models;

namespace api.Mappers
{
    public static class ExhibitMappers
    {
        public static ExhibitDto ToExhibitDto(this Exhibit exhibitModel)
        {
            return new ExhibitDto
            {
                Id = exhibitModel.Id,
                Title = exhibitModel.Title,
                YearOfCreation = exhibitModel.YearOfCreation,
                Price = exhibitModel.Price,
                Technique = exhibitModel.Technique
            };
        }
        public static Exhibit ToExhibitFromCreateDTO(this CreateExhibitRequestDto exhibitDto)
        {
            return new Exhibit
            {
                Title = exhibitDto.Title,
                YearOfCreation = exhibitDto.YearOfCreation,
                Price = exhibitDto.Price,
                Technique = exhibitDto.Technique    
            };
        }
    }
}