using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
