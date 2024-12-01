using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace api.Models
{
    public class Exhibit
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public string Technique { get; set; } = string.Empty;
        public DateOnly? DateOfSale { get; set; }
        public int? ArtistId { get; set; } // навигация (перемещение внутри отношений), внешний ключ
        public Artist? Artist { get; set; }
    }
}