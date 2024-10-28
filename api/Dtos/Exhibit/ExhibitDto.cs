using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Exhibit
{
    public class ExhibitDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfCreation { get; set; }
        public decimal Price { get; set; }
        public string Technique { get; set; } = string.Empty;
    }
}