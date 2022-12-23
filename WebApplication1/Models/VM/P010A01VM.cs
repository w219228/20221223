using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models.VM
{
	public class P010A01VM
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		
		public HttpPostedFileBase File { get; set; }

		public string FileName { get; set; }
	}
}