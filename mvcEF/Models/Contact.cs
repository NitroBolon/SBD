using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcEF.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int IDContact { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Street { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string City { get; set; }
        [StringLength(10, MinimumLength = 5)]
        public string PostalCode { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Email { get; set; }
        public ICollection<Client> clients { get; set; }
    }
}