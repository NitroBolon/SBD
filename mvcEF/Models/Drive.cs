using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Drive
    {
        [Key]
        [Required]
        public int IDDrive { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Memory { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public virtual ICollection<CompDrives> CompDrivess { get; set; }
    }
}