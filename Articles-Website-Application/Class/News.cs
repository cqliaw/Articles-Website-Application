using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Articles_Website_Application.Class
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsVisibleDetails { get; set; }
        public string NewsHiddenDetails { get; set; }
        public string ImageUrl { get; set; }
    }
}