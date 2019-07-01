using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCascade.Models;

namespace MyCascade.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        
        public ActionResult Index()
        {
            MBKTestEntities db = new MBKTestEntities();
            ViewBag.Alist = new SelectList(GetActivityList(), "ActivityId", "ActivityName");
            //ViewBag.StateID = new SelectList(GetSubActivityList(), "StateID", "StateName");
            return View();
        }
        public List<Activity> GetActivityList()
        {
            MBKTestEntities db = new MBKTestEntities();
            List<Activity> activities = db.Activities.ToList();
            return activities;
        }
        public ActionResult GetSubActivityList(int ActivityId)
        {
            MBKTestEntities db = new MBKTestEntities();
            List<SubActivity> subact = db.SubActivities.Where(x=>x.ActivityId == ActivityId).ToList();
            ViewBag.list = new SelectList(subact, "StateID", "StateName");
            return PartialView("GetD");
        }
        [HttpPost]
        public ActionResult Add(Order model)
        {
            //ViewBag.Message = "Your party page.";
            MBKTestEntities db = new MBKTestEntities();
           // List<Order> list = db.Orders.ToList();

            Order par = new Order();

            par.ActivityId = model.ActivityId;
            par.StateID = model.StateID;
        
            db.Orders.Add(par);
            db.SaveChanges();
            
            return RedirectToAction("Index");

        }
    }
}