﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models.EFModels;

namespace WebApplication1.Models.VM
{
	public class ProductIndexVm
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }
		public string ProductName { get; set; }

		public int UnitPrice { get; set; }

		
	}
}