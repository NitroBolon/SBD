using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class mvcEFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public mvcEFContext() : base("name=mvcEFContext")
        {
        }

        public System.Data.Entity.DbSet<mvcEF.Models.Accessories> Accessories { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Computer> Computers { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Casing> Casings { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Cooler> Coolers { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Delivery> Deliveries { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Drive> Drives { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.GraphicsCard> GraphicsCards { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Motherboard> Motherboards { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Peripheral> Peripherals { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.PowerSupply> PowerSupplies { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.Processor> Processors { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.RAM> RAMs { get; set; }

        public System.Data.Entity.DbSet<mvcEF.Models.CompDrives> CompDrives { get; set; }
    }
}
