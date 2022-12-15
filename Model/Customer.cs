using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{   public class CustomerRegister
    {
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Pin { get; set; }
    }
    public class CustomerLogin
    {
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
    }
    public class Customer
    {   [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public int Pin { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
