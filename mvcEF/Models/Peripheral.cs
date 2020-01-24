using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Peripheral
    {
        [Key]
        [Required]
        public int IDPeripheral { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public String Name { get; set; }
        [StringLength(250, MinimumLength = 3)]
        public String Description { get; set; }
        public int Price { get; set; }

        public ICollection<Cart> carts { get; set; }
    }
}