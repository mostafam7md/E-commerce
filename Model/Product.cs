using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{   public class NewProduct
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescrprion { get; set; }
        public int CatogeryId { get; set; }

    }
    public class Product
    {      [Key]
        public int ProductId { get; set; }
        public string Name { get; set;  }   
  
        [Required]
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescrprion { get; set; }
        public OrderItem? orderItem { get; set; }
        public int? OrderItemId { get; set; }
        public Catogery? catogery { get; set; }
        public int? CatogeryId { get; set; }
        public Vendor? vendor { get; set; }
        public int? VendorId { get; set; }
    }
}
