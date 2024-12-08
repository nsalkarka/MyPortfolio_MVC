using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioEntities1 db=new MyPortfolioEntities1();
        // GET: AdminLayout
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner() 
        { 
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar() 
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageURL;
            

            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar() 
        {
            var email = Session["email"].ToString();
            var admin=db.TblAdmins.FirstOrDefault(x=> x.Email == email);

            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageURL;

            var unreadmessages = db.TblMessages.Where(x => x.IsRead == false)
                                              .OrderByDescending(x => x.MessageId)
                                              .Take(3)
                                              .ToList();
            return PartialView(unreadmessages);
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }

    }


}