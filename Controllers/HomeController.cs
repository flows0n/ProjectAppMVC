using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using ProjectApp.Models;

namespace ProjectApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


    public ActionResult Index()
        {
            dynamic myModel = new ExpandoObject();
            myModel.data1 = (from p in db.Products
                         orderby p.AddDate descending
                         select p).Take(4).ToList();


            if (HttpContext.Application["AdminMessage"] != null)
            {
                int id = (int)HttpContext.Application["AdminMessage"];
                myModel.data2 = (from m in db.AdminMessages
                              where m.ID == id
                              select m).Take(1).ToList();
            }
            else
            {
                myModel.data2 = (from m in db.AdminMessages
                                 orderby m.ID descending
                                 select m).Take(1).ToList();
            }
            
            return View(myModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}