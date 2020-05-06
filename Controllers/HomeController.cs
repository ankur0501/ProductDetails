using Code_First_Approach_in_Entity_Framework.Models;
using CRUD_jQuery_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_jQuery_MVC.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: Home
        public ActionResult Index(int page=1)
        {
            ProductContext db = new ProductContext();
            List<Product> products = db.Products.ToList();
            var productView = new ProductViewModel
            {
                productPerPage = 5,
                product = db.Products.OrderBy(d => d.ProductID),
                CurrentPage = page
            };  
            //Add a Dummy Row.
            //products.Insert(0, new Product());
            return View(productView);
        }

        [HttpPost]
        public JsonResult InsertProduct(Product product)
        {
            using (ProductContext entities = new ProductContext())
            {
                entities.Products.Add(product);
                entities.SaveChanges();
            }

            return Json(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            using (ProductContext entities = new ProductContext())
            {
                Product updatedProduct = (from c in entities.Products
                                            where c.ProductID == product.ProductID
                                            select c).FirstOrDefault();
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.CategoryID = product.CategoryID;
                updatedProduct.CategoryName = product.CategoryName;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteProduct(int prodID)
        {
            using (ProductContext entities = new ProductContext())
            {
                Product product = (from c in entities.Products
                                     where c.ProductID == prodID
                                     select c).FirstOrDefault();
                entities.Products.Remove(product);
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}
