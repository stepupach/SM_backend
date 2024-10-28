using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string SchoolOfPainting { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public int? ExhibitId { get; set; } // навигация (перемещение внутри отношений)
        public Exhibit? Exhibit { get; set; }
    }
}