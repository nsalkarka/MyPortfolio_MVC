using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioEntities1 db=new MyPortfolioEntities1();
        public ActionResult Index()
        {
            var values=db.TblTestimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial (int id)
        {
            var value= db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(TblTestimonial model)
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
                db.TblTestimonials.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id) 
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonial model)
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

                var value = db.TblTestimonials.Find(model.TestimonialId);
                value.ImageUrl = model.ImageUrl;
                value.NameSurname = model.NameSurname;
                value.Title = model.Title;
                value.Comment = model.Comment;

            }
           
           
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}