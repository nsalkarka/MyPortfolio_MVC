﻿using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioEntities1 db = new MyPortfolioEntities1();
        public ActionResult Index()
        {
            
            var values=db.TblMessages.Where(n=> n.IsRead == false).ToList();
            return View(values);
        }

        public ActionResult MessageDetail(int id)
        {
            
            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }

        [HttpPost]
        public ActionResult MakeMessageRead(int id)
        {
            var value=db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}