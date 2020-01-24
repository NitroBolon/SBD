using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class CompDrives
    {
        [Key, Column(Order = 1)]
        public int IDDrive { get; set; }
        [Key, Column(Order = 2)]
        public int IDComputer { get; set; }
        public Drive Drive { get; set; }
        public Computer Computer { get; set; }
    }
}