using MVCImageUpload.DesignPatterns.SingletonPattern;
using MVCImageUpload.Models.Context;
using MVCImageUpload.Models.Entities;
using MVCImageUpload.Tools;
using MVCImageUpload.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCImageUpload.Controllers
{
    public class ImageLoadController : Controller
    {
        MyContext _db;
        public ImageLoadController()
        {
            _db = DBTool.DBInstance;
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TestClass testClass,HttpPostedFileBase resim)
        {
            testClass.ImagePath = ImageUploader.UploadImage("/Images/", resim);
            _db.TestClasses.Add(testClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ListTestClasses()
        {
            ImageVM ivm = new ImageVM()
            {
                TestClasses = _db.TestClasses.ToList()
            };
            return View(ivm);
        }
    }
}