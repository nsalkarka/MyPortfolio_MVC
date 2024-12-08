using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioEntities1 db=new MyPortfolioEntities1();
        public ActionResult Index()
        {
            var value=db.TblContacts.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(TblContact model) 
        {
            db.TblContacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult DeleteContact(int id) 
        {
            var value= db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id) 
        {
            var value = db.TblContacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact (TblContact model)
        {
            var value= db.TblContacts.Find(model.ContactId);
            value.Email = model.Email;
            value.Phone = model.Phone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}