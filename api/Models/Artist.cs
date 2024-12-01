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

        public List<Exhibit> Exhibits { get; set; } = new List<Exhibit>(); // навигация (перемещение внутри отношений), внешний ключ
    }
}