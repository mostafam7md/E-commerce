using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{
    public class Wishlist
    {   [Key]
        public int id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescrprion { get; set; }
    }
}
