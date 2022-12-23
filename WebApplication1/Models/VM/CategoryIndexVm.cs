using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.VM
{
	public class CategoryIndexVm
	{
		public int Id { get; set; }
		[Display(Name ="分類名稱")]
		public string CategoryName { get; set; }
		[Display(Name = "商品數量")]
		public int ProductCount { get; set; }

		[Display(Name = "顯示順序")]
		public int DisplayOrder { get; set; }

	}
}