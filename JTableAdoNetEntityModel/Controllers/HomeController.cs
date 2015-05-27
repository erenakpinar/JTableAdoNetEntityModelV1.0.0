using JTableAdoNetEntityModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Threading;


namespace JTableAdoNetEntityModel.Controllers
{
    public class HomeController : Controller
    {
        JTableEntities db = new JTableEntities();
        #region ProductsAllMethods
       
        public List<Products> GetAllProducts()
        {
            return db.Products.OrderBy(s => s.ProductName).ToList();
        }
        public List<Products> GetProductsByFilter(string productName, int categoryId, int startIndex, int count, string sorting)
        {
            IEnumerable<Products> query = db.Products;

            //Filters
            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.IndexOf(productName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            //Sorting
            //This ugly code is used just for demonstration.
            //Normally, Incoming sorting text can be directly appended to an SQL query.
            if (string.IsNullOrEmpty(sorting) || sorting.Equals("ProductName ASC"))
            {
                query = query.OrderBy(p => p.ProductName);
            }
            else if (sorting.Equals("ProductName DESC"))
            {
                query = query.OrderByDescending(p => p.ProductName);
            }

            else if (sorting.Equals("CategoryID ASC"))
            {
                query = query.OrderBy(p => p.CategoryId);
            }
            else if (sorting.Equals("CategoryID DESC"))
            {
                query = query.OrderByDescending(p => p.CategoryId);
            }


            else
            {
                query = query.OrderBy(p => p.ProductName); //Default!
            }

            return count > 0
                       ? query.Skip(startIndex).Take(count).ToList() //Paging
                       : query.ToList(); //No paging
        }
        public Products AddProduct(Products product)
        {

            product.ProductId = db.Products.Count() > 0
                                    ? (db.Products.OrderByDescending(u => u.ProductId).First().ProductId + 1)
                                    : 1;
            db.Products.Add(product);
            db.SaveChanges();

            return product;
        }
        public void UpdateProducts(Products product)
        {
            var foundProduct = db.Products.FirstOrDefault(s => s.ProductId == product.ProductId);
            if (foundProduct == null)
            {
                return;
            }

            foundProduct.ProductName = product.ProductName;
            db.SaveChanges();

        }
        public void DeleteProducts(int productId)
        {
            Products pro = db.Products.FirstOrDefault(u => u.ProductId == productId);
            db.Products.Remove(pro);
            db.SaveChanges();
        }
        public int GetProductCount()
        {
            return db.Products.Count();
        }
        public int GetProductCountByFilter(string productName, int categoryId)
        {
            IEnumerable<Products> query = db.Products;

            //Filters
            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.ProductName.IndexOf(productName, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            return query.Count();
        }
        #endregion
        #region CategoriesAllMethods
        public List<Categories> GetAllCategories()
        {
            return db.Categories.OrderBy(c => c.CategoryName).ToList();
        }
        #endregion
       
        //
        // GET: /Home/
       
        
        public ActionResult Index()
        {
           
            
            var categoriess = GetAllCategories().Select(categories => new SelectListItem { Text = categories.CategoryName, Value = categories.CategoryId.ToString() }).ToList();
            categoriess.Insert(0, new SelectListItem { Selected = true, Text = "All cities", Value = "0" });

            ViewBag.Categories = categoriess;
            return View();
        }
         [HttpPost]
        public JsonResult ProductList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                Thread.Sleep(200);

                var productCount = GetProductCount();
                var products = GetAllProducts();
                return Json(new { Result = "OK", Records = products, TotalRecordCount = productCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult ProductListByFiter(string ProductName = "", int categoryId = 0, int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var productsCount = GetProductCountByFilter(ProductName,categoryId);

                var products = GetProductsByFilter(ProductName, categoryId, jtStartIndex, jtPageSize, jtSorting);
                return Json(new { Result = "OK", Records = products, TotalRecordCount = productsCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult CreateProduct(Products product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                var addedProduct = AddProduct(product);
                return Json(new { Result = "OK", Record = addedProduct });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UpdateProduct(Products product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { Result = "ERROR", Message = "Form is not valid! Please correct it and try again." });
                }

                UpdateProducts(product);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult DeleteProduct(int productId)
        {
            try
            {
                Thread.Sleep(50);
                DeleteProducts(productId);
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
