using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioEntities1 db = new MyPortfolioEntities1();
        public ActionResult Index()
        {

            var socialmedias = db.TblSocialMedias.ToList();

            return View(socialmedias);
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia model)
        {
            db.TblSocialMedias.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialmedia = db.TblSocialMedias.Find(id);
            return View(socialmedia);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia model)
        {
            var value = db.TblSocialMedias.Find(model.SocialMediaId);
            value.Name = model.Name;
            value.Url = model.Url;
           

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}