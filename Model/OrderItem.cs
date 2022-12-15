using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{   
    public class OrderItemDto{
        public int prodId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int OrderId { get; set; }
    }
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int prodId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price {get;set;}
        public ICollection<Product>? products { get; set; }
        public int? OrderId { get; set; }
        public Order? order { get; set; }

    }
}
