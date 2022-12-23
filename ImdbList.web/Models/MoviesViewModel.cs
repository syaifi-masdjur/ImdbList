using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.Extensions.Options;
using System;

namespace ImdbList.web.Models
{
    public class MoviesViewModel
    {
        //public string imDbRatingCount { get; set; }
        //public string year { get; set; }
        //public int id { get; set; }
        public string fullTitle { get; set; }
        public string title { get; set; }
//        public string image { get; set; }
        //public string rank { get; set; }
        //public string rankUpDown { get; set; }
        //public string crew { get; set; }
        public string imDbRating { get; set; }
    }

}
