using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Helpers
{
    public class QueryObjectArtist
    {
        public string? SchoolOfPainting {get; set;} = null;
        public string? FullName {get; set;} = null;
        public string? SortBy {get; set;} = null;
        public bool IsDescending {get; set;} = false;
    }

    public class QueryObjectExhibit 
    {
        [Range(0,1000000000000)]
        public decimal MinPrice { get; set; }
        [Range(0,1000000000000)]
        public decimal MaxPrice { get; set; }
        public string? SortBy {get; set;} = null;
        public bool IsDescending {get; set;} = false;
        public bool Sold {get; set;} = false;
    }

}