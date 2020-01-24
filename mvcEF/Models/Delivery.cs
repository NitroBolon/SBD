using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Delivery
    {
        [Key]
        [Required]
        public int IDDelivery { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}