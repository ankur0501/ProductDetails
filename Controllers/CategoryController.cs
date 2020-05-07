using Code_First_Approach_in_Entity_Framework.Models;
using CRUD_jQuery_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_jQuery_MVC.Controllers
{
    public class CategoryController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            CategoryContext db = new CategoryContext();
            List<Category> categories = db.Categories.ToList();
            //Add a Dummy Row.
            categories.Insert(0, new Category());
            return View(categories);
        }

        [HttpPost]
        public JsonResult InsertCategory(Category category)
        {
            using (CategoryContext entities = new CategoryContext())
            {
                entities.Categories.Add(category);
                entities.SaveChanges();
            }

            return Json(category);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            using (CategoryContext entities = new CategoryContext())
            {
                Category updatedCategory = (from c in entities.Categories
                                          where c.CategoryID == category.CategoryID
                                          select c).FirstOrDefault();
                updatedCategory.CategoryName = category.CategoryName;
                entities.SaveChanges();
            }
            using (ProductContext entities = new ProductContext())
            {
                List<Product> updatedProduct = (from c in entities.Products
                                           where c.CategoryID == category.CategoryID
                                           select c).ToList();
                foreach(var p in updatedProduct)
                {
                    p.CategoryName=category.CategoryName;
                }
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteCategory(int prodID)
        {
            using (CategoryContext entities = new CategoryContext())
            {
                Category product = (from c in entities.Categories
                                    where c.CategoryID == prodID
                                   select c).FirstOrDefault();
                entities.Categories.Remove(product);
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}