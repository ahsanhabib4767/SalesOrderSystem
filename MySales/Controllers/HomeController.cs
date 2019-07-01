using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using System.Data.Entity.Validation;


namespace MySales.Controllers

{
   // [Authorize]
    public class HomeController : Controller
    {
        //OnlineShopEntities2 db = new OnlineShopEntities2();
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
           //creating customers 

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }



}
