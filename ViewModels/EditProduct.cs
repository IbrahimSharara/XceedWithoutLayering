using ProductCategory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.ViewModels
{
    public class EditProduct
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
