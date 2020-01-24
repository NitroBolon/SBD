using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int IDOrder { get; set; }
        [Required]
        public int IDCart { get; set; }
        public Cart cart { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime orderDate { get; set; }

        public int IDDelivery { get; set; }
        public Delivery delivery { get; set; }
        public int IDClient { get; set; }
        public Client client { get; set; }
    }
}