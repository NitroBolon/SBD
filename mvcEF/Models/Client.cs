using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int IDClient { get; set; }
        [StringLength(120, MinimumLength = 3)]
        public string Name { get; set; }
        public int IDContact { get; set; }
        public Contact contact { get; set; }
    }
}