using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class PowerSupply
    {
        [Key]
        [Required]
        public int IDPowerSupply { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Power { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Standard { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Certificate { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }

        public ICollection<Computer> computers { get; set; }
    }
}