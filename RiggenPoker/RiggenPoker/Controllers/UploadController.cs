using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RiggenPoker.Models;
using System.Data.Entity.Migrations;

namespace RiggenPoker.Controllers
{
   
    public class UploadController : Controller
    {
        ApplicationDbContext obj = new ApplicationDbContext();
        // GET: Upload
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc, HttpPostedFileBase file)
        {
            UploadImage tbl = new UploadImage();
            var allowedExtensions = new[] {
            ".png", ".jpg", ".jpeg"
        };
            tbl.Id = fc["Id"].ToString();
            tbl.Image_url = file.ToString(); //getting complete url  
            tbl.ImageName = fc["Name"].ToString();
            var fileName = Path.GetFileName(file.FileName); //getting only file name(ex-ganesh.jpg)  
            var ext = Path.GetExtension(file.FileName).ToLower(); //getting the extension(ex-.jpg)  
            if (allowedExtensions.Contains(ext)) //check what type of extension  
            {
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string myfile = name + "_" + tbl.Id + ext; //appending the name with id  
                                                           // store the file inside ~/Content/Images/UploadedImages  
                var path = Path.Combine(Server.MapPath("~/Content/Images/UploadedImages"), myfile);
                //tbl.Image_url = path;
                //obj.UploadImages.Add(tbl);
                obj.UploadImages.AddOrUpdate(
                    i => i.Id,
                    new UploadImage { Image_url = path  }
                   );
                obj.SaveChanges();
                file.SaveAs(path);
            }
            else
            {
                ViewBag.message = "Går endast att spara bildfiler, t ex: .jpg, .png";
            }
            return View();
        }
    }
}