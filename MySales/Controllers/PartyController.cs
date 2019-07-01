using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySales.Models;
using System.Data.Entity.Validation;
using System.Net;
using System.Data.Entity;

namespace MySales.Controllers
{


    // GET: Home
    [Authorize]
    public class PartyController : Controller
    {
        OnlineShopEntities18 db = new OnlineShopEntities18();
        // GET: Home
        public ActionResult Index()
        {

            OnlineShopEntities18 db = new OnlineShopEntities18();
                //List<Party> list = db.Parties.ToList();
                IEnumerable<Party> partylist = db.Parties.ToList();
                return View();
           
  
}
    //creating entry controller
    [HttpPost]
            public ActionResult Add(Party model)
            {
            //ViewBag.Message = "Your party page.";
            OnlineShopEntities18 db = new OnlineShopEntities18();
                List<Party> list = db.Parties.ToList();
          
            Party par = new Party();
            par.UserId = Convert.ToInt32(Session["UserID"]);
            par.pname = model.pname;
                par.paddress = model.paddress;
                par.pphone = model.pphone;
                db.Parties.Add(par);
                db.SaveChanges();
                int latestpid = par.pid;
                return RedirectToAction("List");

            }
        [HttpGet]
        public ActionResult List()
        {
            OnlineShopEntities18 db = new OnlineShopEntities18();
            
            IEnumerable<Party> partylist = db.Parties.ToList();

            return View(partylist);
        }
      
        // creating details view controller(GET)
      
        public ActionResult Details(int id)
        {
            using(OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Parties.Where(x => x.pid == id).FirstOrDefault());
            }
            
        }
        // creating edit for update
        public ActionResult Edit(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Parties.Where(x => x.pid == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        public ActionResult Edit(int id,Party party)
        {
            try
            {   using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {
                    db.Entry(party).State = EntityState.Modified;
                    db.SaveChanges();
                }
                    return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
           
        }
        /////Delete
        public ActionResult Delete(int id)
        {
            using (OnlineShopEntities18 db = new OnlineShopEntities18())
            {
                return View(db.Parties.Where(x => x.pid == id).FirstOrDefault());
            }
        }
        // Get Edit
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection)
        {
            try
            {
                using (OnlineShopEntities18 db = new OnlineShopEntities18())
                {
                    Party party = db.Parties.Where(x => x.pid == id).FirstOrDefault();
                    db.Parties.Remove(party);

                    db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }

    }//end of controller
    }
