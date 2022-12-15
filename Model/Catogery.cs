using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Model
{
    public class Catogery
    {   [Key]
        public int CatogeryId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Product>? products { get; set; }
    }
}
