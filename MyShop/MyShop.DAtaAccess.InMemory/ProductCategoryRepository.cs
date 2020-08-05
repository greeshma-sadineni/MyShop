using MyShop.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DAtaAccess.InMemory
{
   public  class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> products = new List<ProductCategory>();

        public ProductCategoryRepository()
        {
            products = cache["products"] as List<ProductCategory>;
            if (products == null)
            {
                products = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }
        public void Insert(ProductCategory p)
        {
            products.Add(p);
        }
        public void Update(ProductCategory product)
        {
            ProductCategory productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("product not found");
            }
        }
        public ProductCategory Find(string id)
        {
            ProductCategory product = products.Find(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("product not found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return products.AsQueryable();
        }
        public void Delete(string id)
        {
            ProductCategory productToDelete = products.Find(p => p.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("product not found");
            }
        }
    }
}
