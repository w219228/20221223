using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        
        public ActionResult Index01()
        {
            var db = new AppDbContext();
            var data=db.Products.Include("Category").OrderByDescending(p=>p.UnitPrice).ToList();
                   
            return View(data);
        }
        public ActionResult Index02()
        {
			var db = new AppDbContext();
            var data = db.Products
                .OrderBy(p => p.UnitPrice)
                .Select(p => new
            {
                Id = p.Id,
                ProductName = p.ProductName,
            }).ToList()
            .Select(x => new Product 
            {
                Id=x.Id,
                ProductName=x.ProductName
            });
            return View(data);
        }
		public ActionResult Index()
        {
			var db = new AppDbContext();
            var data = db.Products
                .Select(p => new
                {
                    p.Id,
                    p.ProductName,
                    p.UnitPrice,
                    CategoryName = p.Category.CategoryName
                }).ToList()
                .Select(p => new ProductIndexVm
                {
                    Id = p.Id,
                    CategoryName = p.CategoryName,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice
                });
                return View(data);
		}

	}
}