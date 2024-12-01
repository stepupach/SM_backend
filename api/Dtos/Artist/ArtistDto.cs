using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using api.Dtos.Artist;
using api.Dtos.Exhibit;

namespace api.Dtos.Artist
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string SchoolOfPainting { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }

        public List<ExhibitDto> Exhibits {get; set;}
    }

    public class CreateArtistDto
   {
       public int Id { get; set; }
       [Required]
       [MinLength(1, ErrorMessage = "Имя автора должно состоять хотя бы из 1 символа!")]
       [MaxLength(50, ErrorMessage = "Имя автора не должно превышать 100 символов!")]
       public string FullName { get; set; } = string.Empty;
       [Required]
       [MinLength(5, ErrorMessage = "Направление искусства должно состоять хотя бы из 5 символов!")]
       [MaxLength(100, ErrorMessage = "Направление искусства не должно превышать 100 символов!")]
       public string SchoolOfPainting { get; set; } = string.Empty;
       public DateOnly DateOfBirth { get; set; }
   }

    public class UpdateArtistDto
   {
       [Required]
       [MinLength(1, ErrorMessage = "Имя автора должно состоять хотя бы из 1 символа!")]
       [MaxLength(50, ErrorMessage = "Имя автора не должно превышать 100 символов!")]
       public string FullName { get; set; } = string.Empty;
       [Required]
       [MinLength(5, ErrorMessage = "Направление искусства должно состоять хотя бы из 5 символов!")]
       [MaxLength(100, ErrorMessage = "Направление искусства не должно превышать 100 символов!")]
       public string SchoolOfPainting { get; set; } = string.Empty;
   }

    public class ArtistWithAvgPriceDto
    {
        public string FullName { get; set; } = string.Empty;
        public decimal AveragePrice { get; set; }
        public int NumberOfWorks;
    }
}