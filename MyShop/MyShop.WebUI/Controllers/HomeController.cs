using Microsoft.AspNetCore.Mvc;
using MyShop.core.Contracts;
using MyShop.core.Models;
using MyShop.core.ViewModels;
using MyShop.DAtaAccessSQL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class HomeController : Controller
    {           
        IRepository<Product>context;
        IRepository<ProductCategory> productCategories;
        ProductManagerViewModel viewModel = new ProductManagerViewModel();
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoriesContext)
    {
        context = productContext;
        productCategories = productCategoriesContext;
    }

      /*  public ActionResult Index()

        {
            List<Product> products =context.Collection().ToList();
            return View(products);
        }*/
        public ActionResult Index(string searchString)
        {
            var products = from p in context.Collection()
                         select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Category.Contains(searchString));
            }

            return View(products.ToList());
        }
        public ActionResult FilterProduct(string category)
        {

            DataContext productContext = new DataContext();
            List<Product> filteredProduct = productContext.products.Where(p => p.Category ==category).ToList();


            return View(filteredProduct);
        }
        public ActionResult Details(string id)

        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}