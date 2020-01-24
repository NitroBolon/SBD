using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int IDCart { get; set; }
        public int IDComputer { get; set; }
        public Computer computer { get; set; }
        public int IDAccessory { get; set; }
        public Accessories Accessories { get; set; }
        public int IDPeripheral { get; set; }
        public Peripheral Peripheral { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}