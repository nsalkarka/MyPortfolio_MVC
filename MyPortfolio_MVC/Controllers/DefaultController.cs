﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        MyPortfolioEntities1 db = new MyPortfolioEntities1();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values=db.TblBanners.Where(x=>x.IsShown==true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExpertise()
        {
            var values =db.TblExpertises.ToList();  
            return PartialView(values);
        }

        public PartialViewResult DefaultExperience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEducation()
        {
            var values=db.TblEducations.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage() 
        {
            var contact = db.TblContacts.ToList();
            var socialMedia = db.TblSocialMedias.ToList();

            
            return PartialView(Tuple.Create(contact, socialMedia));
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultAbout()
        {
            var values=db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultSocialMedias()
        {
            var values=db.TblSocialMedias.ToList();
            return PartialView(values); 
        }

        public PartialViewResult DefaultTestimonials() 
        { 
            var values=db.TblTestimonials.ToList();
            return PartialView(values);
        }

        

    }
}