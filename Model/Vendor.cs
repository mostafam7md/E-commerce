using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{   
    public class VendorRegister
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
    }
    public class VendorLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Vendor
    {   [Key]
        public int VendorId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string SSN { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
