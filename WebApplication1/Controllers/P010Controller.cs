using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class P010Controller : Controller
    {
        // GET: P010
        public ActionResult A01()
        {
            return View();
        }
        [HttpPost]
		public ActionResult A01(P010A01VM model)
        {
            if(model.File== null||string.IsNullOrEmpty(model.File.FileName)||model.File.ContentLength==0) {
                model.FileName=string.Empty;
            }
            else
            {
                string path = Server.MapPath("/Uploads");
                string fileName=System.IO.Path.GetFileName(model.File.FileName);
                string newFileName=GetNewFileName(path,fileName);
                string fullPath=System.IO.Path.Combine(path, newFileName);
                try
                {
                    model.File.SaveAs(fullPath);
                    model.FileName= newFileName;
                    return View();
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty,"上傳檔案失敗"+ex.Message);
                }

            }

            return RedirectToAction("index","Home");
        }
        private string GetNewFileName(string path, string fileName)
        {
            string ext=System.IO.Path.GetExtension(fileName);
            string newFileName=string.Empty;
            string fullPath=string.Empty;
            do
            {
                newFileName = Guid.NewGuid().ToString("N") + ext;
                fullPath = System.IO.Path.Combine(path, newFileName);

            } while (System.IO.File.Exists(fullPath) == true);
            return newFileName;
        }

	}
}