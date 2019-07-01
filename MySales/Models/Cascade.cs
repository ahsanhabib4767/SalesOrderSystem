using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySales.Models
{
    public class Cascade
    {
        [Required(ErrorMessage = "Enter State")]
        public string Activity { get; set; }
        [Required(ErrorMessage = "Enter City")]
        public string SubActivity { get; set; }
    }
}