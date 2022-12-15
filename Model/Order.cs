using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{
    public class OrderDTO
    {   [Required]
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public DateTime date { get; set; }
        public List<OrderItemDto> list { get; set; }
    }
    public class Order{
        [Key]
        public int OrderId { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime date { get; set; }
        public ICollection<OrderItem>?orderItems {get;set;}
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
