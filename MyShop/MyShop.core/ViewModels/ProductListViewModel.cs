using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.core.ViewModels
{
     public class ProductListViewModel
    {
        public IEnumerable<Product> products { set; get; }
        public IEnumerable<ProductCategory> productsCategories { set; get; }
    }
}
