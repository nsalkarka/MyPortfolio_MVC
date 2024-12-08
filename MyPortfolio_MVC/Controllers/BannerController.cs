using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioEntities1 db=new MyPortfolioEntities1();
        public ActionResult Index()
        {
            var values=db.TblBanners.ToList();   
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBanner(TblBanner model)
        {
            model.IsShown = true;
            db.TblBanners.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBanner(int id)
        {
            var value=db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBanner(TblBanner model)
        {
            var value= db.TblBanners.Find(model.BannerId);
            value.Title=model.Title;
            value.Description=model.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult ShowBanner(int id) 
        {
            var value = db.TblBanners.Find(id);

            value.IsShown = true;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        
        public ActionResult HideBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            value.IsShown = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}