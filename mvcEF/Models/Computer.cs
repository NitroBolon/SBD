using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcEF.Models
{
    public class Computer
    {
        [Key]
        [Required]
        public int IDComputer { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public int IDCasing { get; set; }
        public Casing Casing { get; set; }
        public int IDPowerSupply { get; set; }
        public PowerSupply PowerSupply { get; set; }
        public int IDMotherboard { get; set; }
        public Motherboard Motherboard { get; set; }
        public int IDProcessor { get; set; }
        public Processor Processor { get; set; }
        public int IDGraphicsCard { get; set; }
        public GraphicsCard GraphicsCard { get; set; }
        public int IDCooler { get; set; }
        public Cooler Cooler { get; set; }
        public int IDRAM { get; set; }
        public RAM RAM { get; set; }

        
        public virtual ICollection<CompDrives> CompDrivess { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}