using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Cooler
    {
        [Key]
        [Required]
        public int IDCooler { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public bool hasFan { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public ICollection<Computer> computers { get; set; }
    }
}