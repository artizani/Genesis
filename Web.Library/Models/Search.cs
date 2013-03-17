using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Library.Models
{
     [Serializable]
    public class Search
    {
        [Required]
        [Display(Name = "Enter A Title Name")]
        public string SearchTerm { get; set; }

    }
}