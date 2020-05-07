using CRUD_jQuery_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Code_First_Approach_in_Entity_Framework.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductContextDB") { }

        public DbSet<Product> Products { get; set; }
    }
    public class CategoryContext : DbContext
    {
        public CategoryContext() : base("ProductContextDB") { }


        public DbSet<Category> Categories { get; set; }
    }
}
