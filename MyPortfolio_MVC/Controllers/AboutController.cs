using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioEntities1 db= new MyPortfolioEntities1();
        public ActionResult Index()
        {
            var values=db.TblAbouts.ToList();
            return View(values);
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(TblAbout model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                // CV dosyası işlemi
                if (model.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "files\\";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }

                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    model.CvUrl = "/files/" + model.CvFile.FileName;  // Veritabanına kaydedilecek CV URL'si
                }

                db.TblAbouts.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value=db.TblAbouts.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model)
        {

            if (ModelState.IsValid)
            {
                var value = db.TblAbouts.Find(model.AboutId);
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                // CV dosyası işlemi
                if (model.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "files\\";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }

                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    model.CvUrl = "/files/" + model.CvFile.FileName;  // Veritabanına kaydedilecek CV URL'si
                }
                
                value.Title = model.Title;
                value.Description = model.Description;
                value.CvUrl = model.CvUrl;
                value.ImageUrl = model.ImageUrl;
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);



           

        } 
    }
}