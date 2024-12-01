using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Artist;

namespace api.Dtos.Exhibit
{
    public class ExhibitDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        public decimal Price { get; set; }
        public string Technique { get; set; } = string.Empty;
        public DateOnly? DateOfSale { get; set; }
        public int? ArtistId { get; set; } // навигация (перемещение внутри отношений)
    }

    public class CreateExhibitDto
    {
        [Required]
        [MinLength(1, ErrorMessage = "Название должно состоять из 1 и более символов!")]
        [MaxLength(100, ErrorMessage = "Название не должно превышать 100 символов!")]
        public string Title { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        [Required]
        [Range(0, 1000000000)]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Техника должна состоять из 5 и более символов!")]
        [MaxLength(100, ErrorMessage = "Техника не должна превышать 100 символов!")]
        public string Technique { get; set; } = string.Empty;
        public DateOnly? DateOfSale { get; set; }
    }

    public class UpdateExhibitPriceDto
    {
        [Required]
        [Range(0, 1000000000)]
        public decimal Price { get; set; }
    }


    public class ExhibitWithSchoolOfPaintingDto
    {
        public string Title { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        public string SchoolOfPainting { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }
}