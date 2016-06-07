using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RiggenPoker.Models;
using System.Data.Entity.Migrations;
using System.Web.Hosting;

namespace RiggenPoker.Controllers
{

    [Authorize(Roles = "Admin, Medlem")]
    public class UploadController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Upload
        public ActionResult Index()
        {
            
            return View(db.UploadImages.OrderByDescending(u => u.Id).ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileNames = Path.GetFileName(file.FileName);
                    var fileExt = Path.GetExtension(file.FileName);
                    var fnm = fileNames + ".png";

                    if (fileExt.ToLower().EndsWith(".png") || fileExt.ToLower().EndsWith(".jpg") || fileExt.ToLower().EndsWith(".gif"))
                    {
                       // var guid = Guid.NewGuid().ToString();
                        var filePath = HostingEnvironment.MapPath("~/Content/Images/UploadedImages/") + fnm;
                        var directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Content/Images/UploadedImages/"));
                        if (directory.Exists == false)
                        {
                            directory.Create();
                        }
                        //ViewBag.FilePath = filePath.ToString();
                        file.SaveAs(filePath);
                        UploadImage pic = new UploadImage()
                        {
                        ImageName = fileNames,
                        Image_url = filePath
                        };
                        db.UploadImages.Add(pic);
                        db.SaveChanges();
                    }
                                     
                }
               
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}