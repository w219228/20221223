using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.EFModels;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
			var db = new AppDbContext();
			var data = db.Categories
				.Select(c => new
				{
					Id=c.Id,
					CategoryName=c.CategoryName,
					ProductCount=c.Products.Count(),
					DisplayOrder=c.DisplayOrder,
				}).ToList()
				.Select(x => new CategoryIndexVm
				{
					Id=x.Id,
					CategoryName=x.CategoryName,
					DisplayOrder=x.DisplayOrder,
					ProductCount=x.ProductCount
				});
			return View(data);
		}
		public ActionResult Index01()
		{
			var db = new AppDbContext();
			var data = db.Categories.Include("Products").ToList();

			return View(data);
		}

	}
}