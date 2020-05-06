using Code_First_Approach_in_Entity_Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_jQuery_MVC.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<Product> product { get; set; }  
        public int productPerPage { get; set; }  
        public int CurrentPage { get; set; }  
  
        public int PageCount()  
        {  
            return Convert.ToInt32(Math.Ceiling(product.Count() / (double)productPerPage));  
        }  
        public IEnumerable<Product> PaginatedProducts()  
        {  
            int start = (CurrentPage - 1) * productPerPage;
            return product.OrderBy(b => b.ProductID).Skip(start).Take(productPerPage);
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}