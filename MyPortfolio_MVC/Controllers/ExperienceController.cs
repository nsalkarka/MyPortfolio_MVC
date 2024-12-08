using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioEntities1 db=new MyPortfolioEntities1();
        public ActionResult Index()
        {
            var values= db.TblExperiences.ToList();
            return View(values);
        }

        public ActionResult DeleteExperience(int id)
        {
            var values= db.TblExperiences.Find(id);
            db.TblExperiences.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult CreateExperience()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateExperience(TblExperience model)
        {
            db.TblExperiences.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experience = db.TblExperiences.Find(id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience model)
        {
            var value= db.TblExperiences.Find(model.ExperienceId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.EndDate   = model.EndDate;
            value.StartDate = model.StartDate;
            value.CompanyName = model.CompanyName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}